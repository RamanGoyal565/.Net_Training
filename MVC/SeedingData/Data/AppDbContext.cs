using SeedingData.Models;
using Microsoft.EntityFrameworkCore;
namespace SeedingData.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("CustomerMaster");
            modelBuilder.Entity<Order>().ToTable("OrderMaster");
            // Customer (1) → Orders (Many)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
