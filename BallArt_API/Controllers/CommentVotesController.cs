#nullable disable
using BallArt_API.Data;
using BallArt_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BallArt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentVotesController : ControllerBase
    {
        private readonly BallArtDataContext _context;

        public CommentVotesController(BallArtDataContext context)
        {
            _context = context;
        }

        // GET: api/CommentVotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentVote>>> GetCommentVotes()
        {
            return await _context.CommentVotes.AsNoTracking().ToListAsync();
        }

        // GET: api/CommentVotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentVote>> GetCommentVote(Guid id)
        {
            var commentVote = await _context.CommentVotes.FindAsync(id);

            if (commentVote == null)
            {
                return NotFound();
            }

            return commentVote;
        }

        // PUT: api/CommentVotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentVote(Guid id, CommentVote commentVote)
        {
            if (id != commentVote.Id)
            {
                return BadRequest();
            }

            _context.Entry(commentVote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentVoteExists(id))
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

        // POST: api/CommentVotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentVote>> PostCommentVote(CommentVote commentVote)
        {
            _context.CommentVotes.Add(commentVote);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCommentVote", new { id = commentVote.Id }, commentVote);
        }

        // DELETE: api/CommentVotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentVote(Guid id)
        {
            var commentVote = await _context.CommentVotes.FindAsync(id);
            if (commentVote == null)
            {
                return NotFound();
            }

            _context.CommentVotes.Remove(commentVote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentVoteExists(Guid id)
        {
            return _context.CommentVotes.Any(e => e.Id == id);
        }
    }
}
