using Kanban.Data;
using Microsoft.AspNetCore.Mvc;
using Kanban.DTO;
using Kanban.Models;
using Microsoft.EntityFrameworkCore;

namespace kanban.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public UserController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetById(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            ProfilePicture = user.ProfilePicture
        };
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDTO user)
    {
        var userExists = await _dbContext.Users.AnyAsync(u => u.Email == user.Email);

        if (userExists)
            return Conflict("Existing User");

        var finalUser = new User
        {
            Name = user.Name,
            Email = user.Email,
            ProfilePicture = user.ProfilePicture,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password)
        };

        _dbContext.Add(finalUser);
        await _dbContext.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new  { id = finalUser.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, UserDTO user)
    {
        var finalUser = await _dbContext.FindAsync<User>(id);

        if (finalUser == null) return NotFound("User not found.");

        finalUser.Name = user.Name;
        finalUser.ProfilePicture = user.ProfilePicture;

        await _dbContext.SaveChangesAsync();

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound("User not found.");
        }

        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}