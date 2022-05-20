using Microsoft.AspNetCore.Authorization;

namespace CustomerService.Api.AuthenticationHandlers
{
    public static class MinimumAgeRequirementExtensions
    {
        public static AuthorizationPolicyBuilder RequireAge(this AuthorizationPolicyBuilder builder, int minimalAge)
        {
            builder.Requirements.Add(new MinimalAgeRequirement(minimalAge));

            return builder;
        }
    }
}
