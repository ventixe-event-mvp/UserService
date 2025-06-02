using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;
using UserService.Services;

namespace UserService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserServiceHandler _userService;
    public UserController(UserServiceHandler userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("by-email")]
    public async Task<ActionResult<User>> GetUserByEmail([FromQuery] string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null)
        {
            return NotFound("Ingen användare med denna Email hittades.");
        }
        return Ok(user);
    }

    [HttpPost]

    public async Task<ActionResult<User>> CreateUser([FromBody]User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var created = await _userService.CreateUserAsync(user);
        return Ok(created);
    }

}
