namespace Kanban.Models;

public class CardRole
{
    public int CardId { get; set; }
    public Card Card { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;
    
    public bool CanView { get; set; }
    public bool CanEdit { get; set; }
    public bool CanDelete { get; set; }
    public bool CanMove { get; set; }

    public DateTime AssignedAt { get; set; }

}