using Microsoft.AspNetCore.Authorization;
using identity_base_api.Infrastructure.System.Models;

namespace identity_base_api.Infrastructure.System.Extensions;

public class AdminAuthorizationExtension : AuthorizationHandler<AdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
    {
        var isAdmin = context.User.FindFirst(claim => claim.Type == "IsAdmin");

        if(isAdmin is null)
            return Task.CompletedTask;

        if(bool.Parse(isAdmin.Value))
            context.Succeed(requirement);

        // var birthDateClaim = context.User.FindFirst(claim => claim.Type == "IsAdmin");

        // if(birthDateClaim is null)
        //     return Task.CompletedTask;

        // var birthDate = Convert.ToDateTime(birthDateClaim.Value);

        // var age = DateTime.Today.Year - birthDate.Year;

        // if(birthDate > DateTime.Today.AddYears(-age)) 
        //     age--;

        // if(age >= requirement.Age)
        //     context.Succeed(requirement);

        return Task.CompletedTask;
    }
}