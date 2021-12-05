using Microsoft.EntityFrameworkCore;

namespace WhereToWatch.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShowService>().HasKey(s => new {s.ServiceId, s.ShowId});
        }

        public DbSet<Service> Service {get; set;}
        public DbSet<Show> Show {get; set;}
        public DbSet<ShowService> ShowService {get; set;}
    }
}
