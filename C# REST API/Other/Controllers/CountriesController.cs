using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIContext;
using CountryNamespace;
using entityf.Models.Country;
using AutoMapper;
using entityf.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace entityf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICountriesRepository countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository)
        {
            this.mapper = mapper;
            this.countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await countriesRepository.GetAllAsync();
            var records = mapper.Map<List<GetCountry>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await countriesRepository.GetDetails(id);

            if (country == null)
            {
                return NotFound();
            }

            var record = mapper.Map<GetCountry>(country);

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles ="Administrator,User")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountry country)
        {
            if (id != country.CountryId)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country2 = await countriesRepository.GetAsync(id);

            if(country2 == null)
            {
                return NotFound();
            }

            mapper.Map(country, country2);

            try
            {
                await countriesRepository.UpdateAsync(country2);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (CountryExists(id) is null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry country)
        {
            //var countryToCreate2 = new Country
            //{
            //    Name = country.Name,
            //    ShortName = country.ShortName,
            //};

            var countryToCreate = mapper.Map<Country>(country);

            await countriesRepository.AddAsync(countryToCreate);

            return CreatedAtAction("GetCountry", new { id = countryToCreate.CountryId }, countryToCreate);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await countriesRepository.GetAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            await countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await countriesRepository.Exists(id);
        }
    }
}
