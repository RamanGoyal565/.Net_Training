using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentHostel.Models;

public partial class CollegeDbContext : DbContext
{
    public CollegeDbContext()
    {
    }

    public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:StudentPortalDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.HostelId).HasName("PK__Hostel__677EEB287A903FCB");

            entity.ToTable("Hostel");

            entity.Property(e => e.Block)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52B992D2B7E26");

            entity.ToTable("Student");

            entity.HasIndex(e => e.HostelId, "UQ__Student__677EEB29EEB0A569").IsUnique();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Hostel).WithOne(p => p.Student)
                .HasForeignKey<Student>(d => d.HostelId)
                .HasConstraintName("FK__Student__HostelI__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
