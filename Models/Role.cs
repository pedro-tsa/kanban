namespace Kanban.Models;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    
    public ICollection<CardRole> CardPermission { get; set; } = new List<CardRole>();
}