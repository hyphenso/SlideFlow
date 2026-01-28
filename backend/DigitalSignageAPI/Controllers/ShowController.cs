using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DigitalSignageAPI.Data;
using System;
using System.Linq;

namespace DigitalSignageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly SignageContext _context;

        public ShowController(SignageContext context)
        {
            _context = context;
        }

        // GET: api/show/active/1
        [HttpGet("active/{deviceId}")]
        public IActionResult GetActiveShow(int deviceId)
        {
            var now = DateTime.Now;

            var show = _context.Shows
                .Include(s => s.Content)
                .Where(s =>
                    s.DeviceId == deviceId &&
                    s.Start <= now &&
                    s.Finish >= now
                )
                .Select(s => new
                {
                    s.ShowId,
                    s.DeviceId,
                    s.Start,
                    s.Finish,
                    Content = new
                    {
                        s.Content.ContentId,
                        s.Content.FileName,
                        s.Content.Description
                    }
                })
                .FirstOrDefault();

            if (show == null)
            {
                return NotFound("No active content for this device.");
            }

            return Ok(show);
        }
    }
}
