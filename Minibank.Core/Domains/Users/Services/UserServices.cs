using Minibank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minibank.Core.Domains.Users.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateAsync(User user)
        {
            await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task UpdateAsync(User user)
        {
            await _userRepository.UpdateAsync(user);
        }
    }
}
