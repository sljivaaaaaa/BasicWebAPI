using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return Ok(await _countryService.GetCountries());
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countryService.GetCountry(id);

            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var createdCountry = await _countryService.CreateCountry(country);
            return CreatedAtAction(nameof(GetCountry), new { id = createdCountry.CountryId }, createdCountry);
        }

        // PUT: api/Countries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            var updatedCountry = await _countryService.UpdateCountry(id, country);
            if (updatedCountry == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _countryService.DeleteCountry(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
