using Microsoft.AspNetCore.Mvc;
using ShiwanshApi.Data;
using ShiwanshApi.Models;

namespace ShiwanshApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LanguagesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLanguages()
        {
            return Ok(_context.Languages.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetLanguage(int id)
        {
            var language = _context.Languages.Find(id);
            if (language == null) return NotFound();
            return Ok(language);
        }

        [HttpPost]
        public IActionResult AddLanguage(Language language)
        {
            _context.Languages.Add(language);
            _context.SaveChanges();
            return Ok("Data added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateLanguage(Language language)
        {
            _context.Languages.Update(language);
            _context.SaveChanges();
            return Ok("Data updated successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLanguageById(int id)
        {
            var language = _context.Languages.Find(id);
            if (language == null) return NotFound();

            _context.Languages.Remove(language);
            _context.SaveChanges();
            return Ok("Data deleted successfully!");
        }
    }
}
