using ManageProfile.Models;
using ManageProfile.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace ManageProfile.DataAccess.Data
{
    public class ManageProfileContext : DbContext
    {
        public ManageProfileContext(DbContextOptions<ManageProfileContext> options) : base(options)
        {
        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
