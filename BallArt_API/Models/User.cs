using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BallArt_API.Models
{
    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Score { get; set; }
        public DateTime DateJoined { get; set; }
        public string? Description { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }

        // Foreign Keys
        public int RoleId { get; set; }


        // Navigation Properties
        //[JsonIgnore]
        public ICollection<Image>? Images { get; set; }
        [JsonIgnore]
        public ICollection<ImageVote>? ImageVotes { get; set; }
        [JsonIgnore]
        public ICollection<ImageReport>? ImageReports { get; set; }
        [JsonIgnore]
        public ICollection<Comment>? Comments { get; set; }
        [JsonIgnore]
        public ICollection<CommentVote>? CommentVotes { get; set; }
        [JsonIgnore]
        public ICollection<CommentReport>? CommentReports { get; set; }
    }
}
