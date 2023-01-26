#nullable disable
using BallArt_API.Data;
using BallArt_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BallArt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentReportsController : ControllerBase
    {
        private readonly BallArtDataContext _context;

        public CommentReportsController(BallArtDataContext context)
        {
            _context = context;
        }

        // GET: api/CommentReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentReport>>> GetCommentReport()
        {
            return await _context.CommentReport.AsNoTracking().ToListAsync();
        }

        // GET: api/CommentReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentReport>> GetCommentReport(Guid id)
        {
            var commentReport = await _context.CommentReport.FindAsync(id);

            if (commentReport == null)
            {
                return NotFound();
            }

            return commentReport;
        }

        // PUT: api/CommentReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentReport(Guid id, CommentReport commentReport)
        {
            if (id != commentReport.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentReportExists(id))
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

        // POST: api/CommentReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentReport>> PostCommentReport(CommentReport commentReport)
        {
            _context.CommentReport.Add(commentReport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentReport", new { id = commentReport.Id }, commentReport);
        }

        // DELETE: api/CommentReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentReport(Guid id)
        {
            var commentReport = await _context.CommentReport.FindAsync(id);
            if (commentReport == null)
            {
                return NotFound();
            }

            _context.CommentReport.Remove(commentReport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentReportExists(Guid id)
        {
            return _context.CommentReport.Any(e => e.Id == id);
        }
    }
}
