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
        Task<User> GetAsync(int id);
        Task CreateAsync(User user);
        Task<IEnumerable<User>> GetUsersAsync();
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}
