using System.ComponentModel.DataAnnotations;
namespace identity_base_api.DTOs;

public class LoginDto
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;
}