using Microsoft.AspNetCore.Mvc;
using identity_base_api.DTOs;
using identity_base_api.Services;

namespace identity_base_api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserDto obj) 
    {
        await _userService.AddUserAsync(obj);

        return StatusCode(201, obj); 
    }

    [HttpGet]
    public async Task<IActionResult> GetUsersPaged([FromQuery] int skip = 0, [FromQuery] int take = 100) 
    {
        var users = await _userService.GetAllUsersAsync(skip, take);
        
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id) 
    {
        var user = await _userService.GetUserByIdAsync(id);
        
        return Ok(user);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto obj) 
    {
        await _userService.UpdateUserAsync(obj, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id) 
    {
        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
}