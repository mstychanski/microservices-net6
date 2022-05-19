using AuthService.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure
{
    public class MyAuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IPasswordHasher<User> passwordHasher;

        public MyAuthService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
        }

        public bool TryAuthorize(string username, string password, out User user)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool isValid, User? user)> TryAuthorizeAsync(string username, string password)
        {
            var user = await userRepository.GetByUsernameAsync(username);

            if(user == null)
            {
                return (false, user);
            }

            var result = passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password);

            return (result == PasswordVerificationResult.Success, user);

        }
    }
}
