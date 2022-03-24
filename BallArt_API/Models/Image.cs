using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Uri { get; set; }
        public int Score { get; set; }
        public string? Description { get; set; }
        public DateTime DatePosted { get; set; }

        // Foreign key
        public Guid UserId { get; set; }
        public User User { get; set; }


        //Navigation Properties
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<ImageVote>? ImageVotes { get; set; }
        public ICollection<ImageReport>? ImageReports { get; set; }
    }
}
