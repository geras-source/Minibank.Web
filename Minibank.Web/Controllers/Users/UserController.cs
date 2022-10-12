using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Minibank.Core.Domains.Users;
using Minibank.Core.Domains.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("Get/{id}")]
        public async Task<UserDto> GetAsync(int id)
        {
            var entity = await _userServices.GetAsync(id);

            if(entity == null) { return null; }

            return new UserDto
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            };
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserDto>> GetUsersAsync() {
            var result = await _userServices.GetUsersAsync();
            return result.Select(it => new UserDto()
            {
                Id = it.Id,
                Login = it.Login,
                Email = it.Email
            });
        }
        [HttpPost("Create")]
        public async Task CreateAsync([FromBody] UserDto entity)
        {
            await _userServices.CreateAsync(new User
            {
                Login = entity.Login,
                Email = entity.Email
            });
        }
        [HttpPut("Update")]
        public async Task UpdateAsync(string id,UserDto entity)
        {
            await _userServices.UpdateAsync(new User
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            });
        }
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _userServices.DeleteAsync(id);
        }
    }
}