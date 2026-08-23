namespace Kanban.Models;

public class Column
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public int Position { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
}