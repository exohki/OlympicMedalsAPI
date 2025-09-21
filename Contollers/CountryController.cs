using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicMedalsAPI.Data;
using OlympicMedalsAPI.Models;

namespace OlympicMedalsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly OlympicContext _context;
        public CountryController(OlympicContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();
            return country;
        }

        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            country.Id = 0;
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCountry), new { id = country.Id }, country);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) return NotFound();

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //*
    }
}
