namespace TaskTrackerBackend.DAL.Models;
public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime Deadline { get; set; }
    public TaskStatus Status { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

public enum TaskStatus
{
    Running,
    Success,
    Failed,
}