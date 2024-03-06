using System.ComponentModel.DataAnnotations;
namespace identity_base_api.DTOs;

public class CreateUserDto
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required]
    [Compare("Password")]
    public string RePassword { get; set; } = null!;
}