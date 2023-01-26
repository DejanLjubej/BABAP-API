#nullable disable
using BallArt_API.Data;
using BallArt_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BallArt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageReportsController : ControllerBase
    {
        private readonly BallArtDataContext _context;

        public ImageReportsController(BallArtDataContext context)
        {
            _context = context;
        }

        // GET: api/ImageReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageReport>>> GetImageReports()
        {
            return await _context.ImageReports.AsNoTracking().ToListAsync();
        }

        // GET: api/ImageReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageReport>> GetImageReport(Guid id)
        {
            var imageReport = await _context.ImageReports.FindAsync(id);

            if (imageReport == null)
            {
                return NotFound();
            }

            return imageReport;
        }

        // PUT: api/ImageReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageReport(Guid id, ImageReport imageReport)
        {
            if (id != imageReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageReportExists(id))
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

        // POST: api/ImageReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageReport>> PostImageReport(ImageReport imageReport)
        {
            _context.ImageReports.Add(imageReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageReport", new { id = imageReport.Id }, imageReport);
        }

        // DELETE: api/ImageReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageReport(Guid id)
        {
            var imageReport = await _context.ImageReports.FindAsync(id);
            if (imageReport == null)
            {
                return NotFound();
            }

            _context.ImageReports.Remove(imageReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageReportExists(Guid id)
        {
            return _context.ImageReports.Any(e => e.Id == id);
        }
    }
}
