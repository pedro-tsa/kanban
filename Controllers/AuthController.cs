using Kanban.Data;
using Kanban.DTO;
using Kanban.Models;
using kanban.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kanban.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly  AppDbContext _dbContext;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext dbContext, TokenService tokenService)
    {
        _dbContext = dbContext;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<object>> Register(CreateUserDTO dto)
    {
        var existingEmail = await _dbContext.Users.AnyAsync(u => u.Email == dto.Email);
        if (existingEmail)
        {
            return BadRequest("Registered Email");
        }

        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        var token = _tokenService.GenerateToken(user);
        return Ok(new {token});
    }

    [HttpPost("login")]
    public async Task<ActionResult<object>> Login(LoginDTO dto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
        {
            return Unauthorized("Email/Senha inválidos.");
        }
        
        var token = _tokenService.GenerateToken(user);
        return Ok(new {token});
    }
}