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
        var result = await _userService.AddUserAsync(obj);

        if(result.Succeeded)
            return StatusCode(201, "User registered successfully");

        return StatusCode(500, result.Errors); 
    }


    [HttpGet]
    public async Task<IActionResult> GetUser(string email) 
    {
        var result = await _userService.GetUserByEmailAsync(email);

        if(result != null)
            return StatusCode(200, result);

        return StatusCode(500, "Error getting User"); 
    }

    // [HttpPatch]
    // public async Task<IActionResult> UpdateUser(UpdateUserDto obj) 
    // {
    //     var result = await _userService.AddUserAsync(obj);

    //     if(result.Succeeded)
    //         return StatusCode(201, "User registered successfully");

    //     return StatusCode(500, result.Errors); 
    // }

    // [HttpDelete]
    // public async Task<IActionResult> DeleteUser(int id) 
    // {
    //     var result = await _userService.AddUserAsync(id);

    //     if(result.Succeeded)
    //         return StatusCode(201, "User registered successfully");

    //     return StatusCode(500, result.Errors); 
    // }
}