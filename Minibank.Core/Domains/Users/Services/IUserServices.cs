using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Users.Services
{
    public interface IUserServices
    {
        User Get(string id);
        void Create(User user);
        IEnumerable<User> GetUsers();
        void Update(User user);
        void Delete(string id);
    }
}
