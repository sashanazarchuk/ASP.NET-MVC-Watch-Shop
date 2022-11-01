using Microsoft.EntityFrameworkCore;
using Data.Models;
using Data.Mock;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data
{
    public class WatchShopDbContext : IdentityDbContext<User>
    {
        public WatchShopDbContext() { }
        public WatchShopDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany(o => o.Orders).WithOne(u => u.User).HasForeignKey(u=>u.UserId);
            modelBuilder.Entity<Watch>().HasData(MockData.GetWatches());
            modelBuilder.Entity<ClockFace>().HasData(MockData.GetClockFace());

        }
        public DbSet<Watch> Watches { get; set; }
        public DbSet<ClockFace> ClockFace { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
