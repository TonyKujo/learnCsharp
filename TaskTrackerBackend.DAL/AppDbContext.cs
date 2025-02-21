namespace TaskTrackerBackend.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskTrackerBackend.DAL.Models;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(x => x.Login).HasMaxLength(10);
            builder.Property(x => x.Password).HasMaxLength(10);
        });

        modelBuilder.Entity<Task>(builder =>
        {
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(300);
        });
    }
}
