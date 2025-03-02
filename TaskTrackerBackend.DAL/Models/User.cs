using System.Collections.Generic;

namespace TaskTrackerBackend.DAL.Models;
public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Task> CreatorTasks = new HashSet<Task>();
    public ICollection<Task> ExecutorTasks = new HashSet<Task>();
}