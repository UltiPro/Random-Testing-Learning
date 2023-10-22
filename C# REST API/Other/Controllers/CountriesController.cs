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
using entityf.Models;
using Microsoft.AspNetCore.OData.Query;

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

        // GET: api/Countries/GetAll
        [HttpGet("GetAll")]
        [EnableQuery] //OData =>Select=name
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await countriesRepository.GetAllAsync<GetCountry>();
            return Ok(countries);
        }

        // GET: api/Countries/?itedanezklasyuknow
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetPagedCountries([FromQuery] QueryParameters queryParameters)
        {
            var pagedResult = await countriesRepository.GetAllAsync<GetCountry>(queryParameters);
            return Ok(pagedResult);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await countriesRepository.GetDetails(id);
            return Ok(country);
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

            try
            {
                await countriesRepository.UpdateAsync(id, country);
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

            //var countryToCreate = mapper.Map<Country>(country);

            //await countriesRepository.AddAsync(countryToCreate);

            var county2 = await countriesRepository.AddAsync<CreateCountry, GetCountry>(country);

            return CreatedAtAction(nameof(GetCountry), new { id = county2.Id }, county2);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await countriesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await countriesRepository.Exists(id);
        }
    }
}
