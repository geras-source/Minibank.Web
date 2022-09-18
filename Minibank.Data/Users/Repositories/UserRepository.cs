using System;
using System.Collections.Generic;
using System.Linq;
using Minibank.Core.Domains.Users;
using Minibank.Core.Repositories;

namespace Minibank.Data.Users.Repositories
{
    class UserRepository : IUserRepository
    {
        private static List<UserEntity> _userEntity = new List<UserEntity>();

        public void Create(User user)
        {
            var entity = new UserEntity
            {
                Id = Guid.NewGuid().ToString(),
                Login = user.Login,
                Email = user.Email
            };

            _userEntity.Add(entity);

        }

        public void Delete(string id)
        {
            var entity = _userEntity.FirstOrDefault(it => it.Id == id);

            if(entity != null)
            {
                _userEntity.Remove(entity);
            }
        }

        public User Get(string id)
        {
            var entity = _userEntity.FirstOrDefault(it => it.Id == id);

            if (entity == null) { return null; }

            return new User
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            };
        }

        public IEnumerable<User> GetUsers()
        {
            return _userEntity.Select(it => new User()
            {
                Id = it.Id,
                Login = it.Login,
                Email = it.Email
            });
        }

        public void Update(User user)
        {
            var entity = _userEntity.FirstOrDefault(it => it.Id == user.Id);

            if(entity != null)
            {
                entity.Login = user.Login;
                entity.Email = user.Email;
            }
        }
    }
}