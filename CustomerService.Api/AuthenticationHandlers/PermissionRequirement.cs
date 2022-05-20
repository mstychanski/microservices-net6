using Microsoft.AspNetCore.Authorization;

    namespace CustomerService.Api.AuthenticationHandlers
    {
        public class PermissionRequirement : IAuthorizationRequirement // marked interface
        {
            public string Permission { get; }

            public PermissionRequirement(string permission)
            {
                Permission = permission;
            }
        }
    }

