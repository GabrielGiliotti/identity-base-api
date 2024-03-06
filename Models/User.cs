using Microsoft.AspNetCore.Identity;

namespace identity_base_api.Models;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }
    public User() : base() { }
}