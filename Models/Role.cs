namespace Kanban.Models;

public class Role
{
    public string Name { get; set; } = string.Empty;

    public EnumPermissions Permission { get; set; } 

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}