namespace Kanban.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }
}

public class UpdateUserDTO
{
    public string Name { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }
}

public class CreateUserDTO
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }
}

