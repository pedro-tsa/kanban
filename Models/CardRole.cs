namespace Kanban.Models;

public class CardRole
{
    public int CardId { get; set; }
    public Card Card { get; set; } = null!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = null!;

    public DateTime AssignedAt { get; set; }

}