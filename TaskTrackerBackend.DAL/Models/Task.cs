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
    public bool IsExpired = false;
    public int CreatorId { get; set; }
    public ICollection<TaskExecutor>? TaskExecutors { get; set; }
    public User User { get; set; }
}