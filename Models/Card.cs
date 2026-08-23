namespace Kanban.Models;

public class Card
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Content { get; set; }
    public string? Attachments { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Position { get; set; }

    
    //Which cards can be accessed by which roles
    public ICollection<CardRole> CardRoles { get; set; } = new List<CardRole>();

    public int ColumnId { get; set; }
    public Column Column { get; set; } = null!;
}