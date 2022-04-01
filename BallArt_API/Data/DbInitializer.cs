using BallArt_API.Models;
namespace BallArt_API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(BallArtDataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Roles.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role{Id=0, Name="Administrator", Description="Has all the capabilities a user can ask for" },
                new Role{Id=1, Name="BasicUser", Description="Can View Content" }
            };
            foreach (Role role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();

            var users = new User[]
            {
                new User
                {
                    Id=new Guid(),
                    Name="Best User",
                    Score=0,
                    DateJoined=DateTime.Now,
                    Description = "This is the best user, that's why he's an admin",
                    Email = "best.user@bestmail.com",
                    RoleId = 0
                },
                new User
                {
                    Id=new Guid(),
                    Name="Not Best User",
                    Score=10,
                    DateJoined=DateTime.Now,
                    Description = "This is not the best user, that's why he's not an admin",
                    Email = "not.best.user@notbestmail.com",
                    RoleId = 1
                }
            };
            foreach (User user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
            context.Dispose();
        }
    }
}
