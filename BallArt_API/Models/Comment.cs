using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BallArt_API.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime DatePosted { get; set; }
        [StringLength(500)]
        public string Text { get; set; }
        public int Score { get; set; }

        // Foreign Keys
        public Guid UserId { get; set; }
        public Guid ImageId { get; set; }
        public Guid? CommentId { get; set; }

        // Navigation Property
        [JsonIgnore]
        public ICollection<Comment>? Comments { get; set; }
        [JsonIgnore]
        public ICollection<CommentVote>? CommentVotes { get; set; }
        [JsonIgnore]
        public ICollection<CommentReport>? CommentReports { get; set; }

    }
}
