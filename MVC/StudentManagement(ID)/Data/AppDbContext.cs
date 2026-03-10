using Microsoft.EntityFrameworkCore;
namespace StudentManagement_ID_.Data
{
    public class AppDbContext:DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Semester> Semesters { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Semester>().ToTable("SemesterMaster");
            modelBuilder.Entity<Models.Student>().ToTable("StudentMasterIDCard");

            modelBuilder.Entity<Models.Student>()
                .HasMany(s => s.Semesters)
                .WithOne(s => s.Students)
                .HasForeignKey(s => s.StudentId);
        }
    }
}
