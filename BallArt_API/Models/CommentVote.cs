using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class CommentVote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool Liked { get; set; }

        // Foreign Keys
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
