using Microsoft.AspNetCore.Authorization;

namespace identity_base_api.Infrastructure.System.Models;

public class AdminRequirement : IAuthorizationRequirement
{
    public bool IsAdmin { get; set; }
    
    // public int Age { get; set; }
    // public AdminRequirement(int age) 
    // {
    //     Age = age;
    // }
}