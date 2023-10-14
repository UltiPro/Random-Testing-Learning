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

namespace entityf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly API _context;
        private readonly IMapper mapper;

        public CountriesController(API context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            var records = mapper.Map<List<GetCountry>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.CountryId == id);

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
        public async Task<IActionResult> PutCountry(int id, UpdateCountry country)
        {
            if (id != country.CountryId)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country2 = await _context.Countries.FindAsync(id);

            if(country2 == null)
            {
                return NotFound();
            }

            mapper.Map(country, country2);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

            _context.Countries.Add(countryToCreate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountry", new { id = countryToCreate.CountryId }, countryToCreate);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.CountryId == id);
        }
    }
}
