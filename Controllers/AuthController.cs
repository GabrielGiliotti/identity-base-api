using Microsoft.AspNetCore.Mvc;
using identity_base_api.DTOs;
using identity_base_api.Services;

namespace identity_base_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<UserController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto) 
    {
        var result = await _authService.LoginAsync(dto);

        var textResult = $"Login action for user {dto.Username}: {result.Succeeded}";

        if(result.Succeeded)
            return StatusCode(200, textResult);

        return StatusCode(500, textResult); 
    }
}