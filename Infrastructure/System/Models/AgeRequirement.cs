using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace identity_base_api.Infrastructure.System.Models;

public class AgeRequirement : IAuthorizationRequirement
{
    public int Age { get; set; }

    public AgeRequirement(int age) 
    {
        Age = age;
    }
}