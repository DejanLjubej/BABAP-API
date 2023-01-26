using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BallArt_API.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(2000)]
        public string Uri { get; set; }
        public int Score { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public DateTime DatePosted { get; set; }

        // Foreign key
        public Guid UserId { get; set; }


        //Navigation Properties
        [JsonIgnore]
        public ICollection<Comment>? Comments { get; set; }
        [JsonIgnore]
        public ICollection<ImageVote>? ImageVotes { get; set; }
        [JsonIgnore]
        public ICollection<ImageReport>? ImageReports { get; set; }
    }
}
