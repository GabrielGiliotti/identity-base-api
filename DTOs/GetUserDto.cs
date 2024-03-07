using System.ComponentModel.DataAnnotations;
namespace identity_base_api.DTOs;

public class GetUserDto
{
    public string? Username { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public bool IsAdmin { get; set; } 
}