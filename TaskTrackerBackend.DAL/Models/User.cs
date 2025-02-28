namespace TaskTrackerBackend.DAL.Models;
public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public ICollection<Task> Tasks = new HashSet<Task>();
    public ICollection<TaskExecutor>? TaskExecutors { get; set; }
}