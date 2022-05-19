using Core.Domain;
using Core.Intrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Domain
{
    public interface IUserRepository : IEntityRepository<int, User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
