using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime DateJoined { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }

        // Foreign Keys
        public int RoleId { get; set; }
        public Role Role { get; set; }


        // Navigation Properties
        public ICollection<Image>? Images { get; set; }
        public ICollection<ImageVote>? ImageVotes { get; set; }
        public ICollection<ImageReport>? ImageReports { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<CommentVote>? CommentVotes { get; set; }
        public ICollection<CommentReport>? CommentReports { get; set; }
    }
}
