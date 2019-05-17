using System.Data.Entity;


namespace MonumentsApp.Models
{
    public class MonumentsAppContext : DbContext
    {
        public MonumentsAppContext():base("DefaultConnection")
        {
        }

        public DbSet<Monument> Monuments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MonumentQueue> MonumentsQueue { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }


    }
}
