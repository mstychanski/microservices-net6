using Microsoft.AspNetCore.Identity;

namespace DriverService.Api.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Account { get; set; }
    }
}
