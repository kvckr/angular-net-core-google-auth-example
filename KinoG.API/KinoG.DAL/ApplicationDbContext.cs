using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KinoG.API
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions options)
              : base(options)
        {
        }

        public DbSet<Profile> Profile { get; set; }
    }

    public class Profile
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public IdentityUser Identity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
    }
}
