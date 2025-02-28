namespace TaskTrackerBackend.DAL;
using Microsoft.EntityFrameworkCore;
using TaskTrackerBackend.DAL.Models;
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;
    public DbSet<TaskExecutor> TaskExecutors { get; set; }


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
            builder.HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.CreatorId);
            builder.Property(x => x.Title).HasMaxLength(128);
            builder.Property(x => x.Description).HasMaxLength(300);
        });

        modelBuilder.Entity<TaskExecutor>(builder =>
        {
            builder.HasKey(te => new { te.TaskId, te.UserId });

            builder.HasOne(te => te.Task)
                .WithMany(t => t.TaskExecutors)
                .HasForeignKey(te => te.TaskId);

            builder.HasOne(te => te.User)
                .WithMany(u => u.TaskExecutors)
                .HasForeignKey(te => te.UserId);
        });
    }
}
