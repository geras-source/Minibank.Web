using Minibank.Core.Domains.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(string id);
        void Create(User user);
        IEnumerable<User> GetUsers();
        void Update(User user);
        void Delete(string id);
    }
}
