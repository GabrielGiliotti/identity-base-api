namespace identity_base_api.DTOs;

public class UpdateUserDto
{
	public string? UserName { get; set; }
    public string? Email { get; set; }	
    public string? PhoneNumber { get; set; }
    public bool IsAdmin { get; set; }
}