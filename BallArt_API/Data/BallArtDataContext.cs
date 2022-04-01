using BallArt_API.Models;
using Microsoft.EntityFrameworkCore;

namespace BallArt_API.Data
{
    public class BallArtDataContext : DbContext
    {
        public BallArtDataContext(DbContextOptions<BallArtDataContext> options) : base(options)
        {}

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ImageVote> ImageVotes { get; set; }
        public DbSet<ImageReport> ImageReports { get; set; }
        public DbSet<CommentVote> CommentVotes { get; set; }
        public DbSet<CommentReport> CommentReport { get; set; }

    }
}
