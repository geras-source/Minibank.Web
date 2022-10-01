using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Minibank.Core.Domains.Users;
using Minibank.Core.Repositories;

namespace Minibank.Data.Users.Repositories
{
    class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(User user)
        {
            var entity = new UserEntity
            {
                Login = user.Login,
                Email = user.Email
            };

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(it => it.Id == id);

            if(entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);

            if (entity == null) { return null; }

            return new User
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            };
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.Select(it => new User()
            {
                Id = it.Id,
                Login = it.Login,
                Email = it.Email
            }).ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            var entity = await _context.Users.SingleAsync(it => it.Id == user.Id);
            
            if(entity != null)
            {
                entity.Login = user.Login;
                entity.Email = user.Email;
                await _context.SaveChangesAsync();
            }
        }
    }
}