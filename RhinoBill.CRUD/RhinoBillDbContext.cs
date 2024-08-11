using Microsoft.EntityFrameworkCore;
using RhinoBill.CRUD.Models;

namespace RhinoBill.CRUD;

public class RhinoBillDbContext : DbContext
{
    public RhinoBillDbContext(DbContextOptions<RhinoBillDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Application> Applications { get; set; }
}
