using Microsoft.AspNetCore.Authorization;
using identity_base_api.Infrastructure.System.Models;

namespace identity_base_api.Infrastructure.System.Extensions;

public class AgeAuthorizationExtension : AuthorizationHandler<AdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AdminRequirement requirement)
    {
        var birthDateClaim = context.User.FindFirst(claim => claim.Type == "IsAdmin");

        if(birthDateClaim is null)
            return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthDateClaim.Value);

        var age = DateTime.Today.Year - birthDate.Year;

        if(birthDate > DateTime.Today.AddYears(-age)) 
            age--;

        if(requirement.IsAdmin)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}