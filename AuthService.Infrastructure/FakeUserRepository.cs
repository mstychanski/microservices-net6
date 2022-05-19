using AuthService.Domain;
using Bogus;
using Core.Intrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Infrastructure
{
    public class FakeUserRepository : FakeEntityRepository<int, User>, IUserRepository
    {
        public FakeUserRepository(Faker<User> faker) : base(faker)
        {
        }

        public Task<User> GetByUsernameAsync(string username)
        {
            // nie jest to odporne na null. przydałoby się w repository utworzyć metode exists, która sprawdzałaby czy dany użytkownik istnieje
            var user = _entities.SingleOrDefault(u => u.Value.UserName == username);

            return Task.FromResult(user.Value);
        }
    }
}
