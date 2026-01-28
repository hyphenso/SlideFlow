using Microsoft.AspNetCore.Mvc;
using DigitalSignageAPI.Data;
using DigitalSignageAPI.Models;

namespace DigitalSignageAPI.Controllers
{
    [ApiController]
    [Route("api/slides")]
    public class SlidesController : ControllerBase
    {
        private readonly SignageContext _context;

        public SlidesController(SignageContext context)
        {
            _context = context;
        }

        // ✅ SAVE SLIDE (HTML → API → DB)
        [HttpPost]
        public async Task<IActionResult> SaveSlide([FromBody] Slide slide)
        {
            Console.WriteLine("🔥 SAVE SLIDE HIT");
            _context.Slides.Add(slide);
            await _context.SaveChangesAsync();
            return Ok(slide);
        }

        // ✅ GET SLIDES (DB → API)
        [HttpGet]
        public IActionResult GetSlides()
        {
            return Ok(_context.Slides.ToList());
        }
    }
}
