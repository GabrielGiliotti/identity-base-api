using Microsoft.AspNetCore.Authorization;
using identity_base_api.Infrastructure.System.Models;

namespace identity_base_api.Infrastructure.System.Extensions;

public class AgeAuthorizationExtension : AuthorizationHandler<AgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
    {
        var birthDateClaim = context.User.FindFirst(claim => claim.Type == "BirthDate");

        if(birthDateClaim is null)
            return Task.CompletedTask;

        var birthDate = Convert.ToDateTime(birthDateClaim.Value);

        var age = DateTime.Today.Year - birthDate.Year;

        if(birthDate > DateTime.Today.AddYears(-age)) 
            age--;

        if(age >= requirement.Age)
            context.Succeed(requirement);

        return Task.CompletedTask;
    }
}