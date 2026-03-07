using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
namespace StudentManagement.Data
{
    public class StudentManagementContext:DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<HostelRoom> HostelRooms { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("StudentMaster");
            modelBuilder.Entity<Student>()
                .HasOne(s => s.AssignedRoom)
                .WithOne(r => r.ResidentStudent)
                .HasForeignKey<HostelRoom>(r => r.StudentId);
            modelBuilder.Entity<HostelRoom>().HasIndex(r => r.StudentId).IsUnique();
        }
    }
}
