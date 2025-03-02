namespace TaskTrackerBackend.DAL.Models;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime Deadline { get; set; }
    public TaskStatus Status { get; set; }
    public bool IsExpired = false;
    public int CreatorId { get; set; }
    public int? ExecutorId { get; set; }
    public User Creator { get; set; } = null!;
    public User? Executor { get; set; }
}