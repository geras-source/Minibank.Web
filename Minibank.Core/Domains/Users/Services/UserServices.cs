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
        public void Create(User user)
        {
            _userRepository.Create(user);
        }

        public void Delete(string id)
        {
            _userRepository.Delete(id);
        }

        public User Get(string id)
        {
            return _userRepository.Get(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
        }
    }
}
