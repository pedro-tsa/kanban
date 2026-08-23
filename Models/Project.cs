namespace Kanban.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public int Position { get; set; }

    public int OwnerId { get; set; }
    public User Owner { get; set; } = null!;

    //Collaborators of the project
    public ICollection<User> Users { get; set; } = new List<User>();
    public ICollection<Column> Columns { get; set; } = new List<Column>();
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public bool IsPrivate { get; set; }
}