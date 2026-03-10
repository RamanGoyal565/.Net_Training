using Microsoft.EntityFrameworkCore;
using StudentManagementOneToMany.Models;

namespace StudentManagementOneToMany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<HostelRoom> HostelRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("StudentMasterOtoM");
            modelBuilder.Entity<HostelRoom>().ToTable("HostelMasterOtoM");
            modelBuilder.Entity<Payment>().ToTable("PaymenttMasterOtoM");
            // HostelRoom (1) → Students (Many)

            modelBuilder.Entity<Student>()
                .HasOne(s => s.AssignedRoom)
                .WithMany(r => r.Students)
                .HasForeignKey(s => s.HostelRoomId);

            // Student (1) → Payment (1)

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Payment)
                .WithOne(p => p.Student)
                .HasForeignKey<Payment>(p => p.StudentId);
        }
    }
}