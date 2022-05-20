using Microsoft.AspNetCore.Authorization;

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
}
