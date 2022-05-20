    using Microsoft.AspNetCore.Authorization;

    namespace CustomerService.Api.AuthenticationHandlers
    {
        public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
        {
            protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
            {
                var permissions = context.User.Claims
                    .Where(c => c.Type == "Permission")
                    .Select(p => p.Value);

                if (permissions.Contains(requirement.Permission))
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

