using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CustomerService.Api.AuthenticationHandlers
{
    public class MinimalAgeHandler : AuthorizationHandler<MinimalAgeRequirement>
    {

            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimalAgeRequirement requirement)
        {
            DateTime dateOfBirth = Convert.ToDateTime(context.User.FindFirstValue(ClaimTypes.DateOfBirth));

            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (age >= requirement.MinimalAge)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
