using AuthService.Domain;
using Bogus;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure
{
    public class UserFaker : Faker<User>
    {

        //dotnet add package Microsoft.AspNetCore.Identity

        //PasswordHasher
        //ASP.NET Core Identity Version 3
        public UserFaker(IPasswordHasher<User> passwordHasher)
        {
            UseSeed(1); //seed ustawiona jakaś stała, aby Bogus generował przy każdym starcie tę samą listę
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.HashedPassword, (f, user) => passwordHasher.HashPassword(user, "12345"));
            RuleFor(p => p.Email, f => f.Person.Email);
            RuleFor(p => p.Phone, f => f.Person.Phone);
            RuleFor(p => p.UserName, f => f.Person.UserName);
            RuleFor(p => p.Gender, f => (Gender)f.Person.Gender);
            RuleFor(p => p.Birthday, f => f.Person.DateOfBirth);
        }
    }
}
