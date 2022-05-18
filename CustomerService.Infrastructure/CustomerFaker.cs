using Bogus;
using CustomerService.Domain;
using Bogus.Extensions.Poland;

namespace CustomerService.Infrastructure
{
    // dotnet add package Bogus

    // dotnet add package Sulmar.Bogus.Extensions.Poland
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker()
        {
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Gender, f => (Gender) f.Person.Gender);
            RuleFor(p => p.Email, (f, c) => $"{c.FirstName}.{c.LastName}@domain.com"); // firstname.lastname@domain.com
            RuleFor(p => p.Pesel, f => f.Person.Pesel());
            RuleFor(p=>p.IsRemoved, f=>f.Random.Bool(0.2f));
        }
    }
}
