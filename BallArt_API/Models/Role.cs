using System.ComponentModel.DataAnnotations.Schema;

namespace BallArt_API.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Property
        public ICollection<User> Users { get; set; }
    }
}
