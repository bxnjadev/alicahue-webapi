using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Data;

public class ApplicationDbContext : DbContext
{
    
    public ApplicationDbContext() {}
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ) : base(options) {}

    public DbSet<User> Users { get; set; }

    public DbSet<Course> Courses { get; set; } 

    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {

        modelBuilder.Entity<Course>()
            .ToTable("Courses", "public");
        
        modelBuilder.Entity<Block>()
            .ToTable("blocks", "public");
        
        modelBuilder.Entity<Professor>()
            .ToTable("professors", "public");
        
        modelBuilder.Entity<Course>()
            .HasMany(c => c.Blocks)
            .WithOne(b => b.Course)
            .HasForeignKey(b => b.IdCourse);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Professors)
            .WithOne(p => p.Course)
            .HasForeignKey(p => p.IdCourse);

    }
    
}