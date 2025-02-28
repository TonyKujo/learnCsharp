namespace TaskTrackerBackend.DAL.Models;

public class TaskExecutor
{
    public int TaskId { get; set; }
    public Task Task { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
