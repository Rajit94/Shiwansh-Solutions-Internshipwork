using Microsoft.AspNetCore.Mvc;
using ShiwanshApi.Data;
using ShiwanshApi.Models;

namespace ShiwanshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CountriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            return Ok(_context.Countries.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null) return NotFound();
            return Ok(country);
        }

        [HttpPost]
        public IActionResult AddCountry(Country country)
        {
            _context.Countries.Add(country);
            _context.SaveChanges();
            return Ok("Data added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            _context.SaveChanges();
            return Ok("Data updated successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCountryById(int id)
        {
            var country = _context.Countries.Find(id);
            if (country == null) return NotFound();

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return Ok("Data deleted successfully!");
        }
    }
}
