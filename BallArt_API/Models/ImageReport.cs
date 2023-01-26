using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class ImageReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }

        // Foreign Keys
        public Guid UserId { get; set; }
        public Guid ImageId { get; set; }
    }
}
