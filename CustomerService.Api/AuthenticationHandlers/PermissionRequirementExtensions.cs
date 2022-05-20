using Microsoft.AspNetCore.Authorization;

namespace CustomerService.Api.AuthenticationHandlers
{
    public static class PermissionRequirementExtensions
    {
        public static AuthorizationPolicyBuilder RequirePermission(this AuthorizationPolicyBuilder builder, string permission)
        {
            builder.Requirements.Add(new PermissionRequirement(permission));

            return builder;
        }
    }
}
