using Microsoft.EntityFrameworkCore;
using StudentHostelWithJWT.Models;

namespace StudentHostelWithJWT.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }

    public DbSet<Room> Rooms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Room)
            .WithOne(r => r.Student)
            .HasForeignKey<Student>(s => s.RoomId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}