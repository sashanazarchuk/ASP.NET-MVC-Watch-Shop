using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;
namespace Data
{
    public class WatchShopDbContext : DbContext
    {
        public WatchShopDbContext() { }
        public WatchShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Watch>().HasData(MockData.GetWatches());
            modelBuilder.Entity<ClockFace>().HasData(MockData.GetClockFace());

        }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<ClockFace> ClockFace { get; set; }


    }
}
