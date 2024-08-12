using Microsoft.EntityFrameworkCore;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD;

public class RhinoBillDbContext : DbContext
{
    public RhinoBillDbContext(DbContextOptions<RhinoBillDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Application> Applications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
  
        modelBuilder.Entity<Application>()
            .HasKey(a => a.Id);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Student)
            .WithMany(s => s.Applications)
            .HasForeignKey(a => a.StudentId);

        modelBuilder.Entity<Application>()
            .HasOne(a => a.Course)
            .WithMany(c => c.Applications)
            .HasForeignKey(a => a.CourseId);
    }
}
