namespace TaskTrackerBackend.DAL;
using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.DAL.Models;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(x => x.Login)
            .HasMaxLength(10);
            builder.Property(x => x.Password).HasMaxLength(10);
            builder.HasIndex(u => u.Login)
            .IsUnique();
        });

        modelBuilder.Entity<Task>(builder =>
        {
            builder.HasOne(t => t.Creator)
            .WithMany(u => u.CreatorTasks)
            .HasForeignKey(t => t.CreatorId);

            builder.HasOne(t => t.Executor)
            .WithMany(u => u.ExecutorTasks)
            .HasForeignKey(t => t.ExecutorId);

            builder.Property(x => x.Title).HasMaxLength(128);

            builder.Property(x => x.Description).HasMaxLength(300);

        });
    }
}
