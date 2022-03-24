using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }
        public int Score { get; set; }

        // Foreign Keys
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public Guid? CommentId { get; set; }
        public Comment? ParentComment { get; set; }

        // Navigation Property
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<CommentVote>? CommentVotes { get; set; }
        public ICollection<CommentReport>? CommentReports { get; set; }

    }
}
