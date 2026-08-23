namespace Kanban.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }

    public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();
    public ICollection<Project> CollaboratingProjects { get; set; } = new List<Project>();
    public ICollection<Project> FavoriteProjects { get; set; } = new List<Project>();
}