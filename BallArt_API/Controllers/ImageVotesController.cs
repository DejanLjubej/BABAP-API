#nullable disable
using BallArt_API.Data;
using BallArt_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BallArt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageVotesController : ControllerBase
    {
        private readonly BallArtDataContext _context;

        public ImageVotesController(BallArtDataContext context)
        {
            _context = context;
        }

        // GET: api/ImageVotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageVote>>> GetImageVotes()
        {
            return await _context.ImageVotes.ToListAsync();
        }

        // GET: api/ImageVotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageVote>> GetImageVote(Guid id)
        {
            var imageVote = await _context.ImageVotes.FindAsync(id);

            if (imageVote == null)
            {
                return NotFound();
            }

            return imageVote;
        }

        // PUT: api/ImageVotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutImageVote(Guid id, ImageVote imageVote)
        {
            if (id != imageVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(imageVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageVoteExists(id))
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

        // POST: api/ImageVotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ImageVote>> PostImageVote(ImageVote imageVote)
        {
            _context.ImageVotes.Add(imageVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetImageVote", new { id = imageVote.Id }, imageVote);
        }

        // DELETE: api/ImageVotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImageVote(Guid id)
        {
            var imageVote = await _context.ImageVotes.FindAsync(id);
            if (imageVote == null)
            {
                return NotFound();
            }

            _context.ImageVotes.Remove(imageVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ImageVoteExists(Guid id)
        {
            return _context.ImageVotes.Any(e => e.Id == id);
        }
    }
}
