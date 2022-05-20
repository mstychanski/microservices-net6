using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CustomerService.Api.AuthenticationHandlers
{
    public class MinimalAgeRequirement : IAuthorizationRequirement // marked interface
    {
        public int MinimalAge { get; }

        public MinimalAgeRequirement(int minimalAge)
        {
            MinimalAge = minimalAge;
        }
    }

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

    public static class MinimumAgeRequirementExtensions
    {
        public static AuthorizationPolicyBuilder RequireAge(this AuthorizationPolicyBuilder builder, int minimalAge)
        {
            builder.Requirements.Add(new MinimalAgeRequirement(minimalAge));

            return builder;
        }
    }
}
