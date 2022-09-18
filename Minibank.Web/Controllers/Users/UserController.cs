using Microsoft.AspNetCore.Mvc;
using Minibank.Core.Domains.Users;
using Minibank.Core.Domains.Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minibank.Web.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet("Get")]
        public UserDto Get(string id)
        {
            var entity = _userServices.Get(id);

            if(entity == null) { return null; }

            return new UserDto
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            };
        }
        [HttpGet("GetAll")]
        public IEnumerable<UserDto> GetUers() {
            return _userServices.GetUsers().Select(it => new UserDto()
            {
                Id = it.Id,
                Login = it.Login,
                Email = it.Email
            });
        }
        [HttpPost("Create")]
        public void Create(UserDto entity)
        {
            _userServices.Create(new User
            {
                Login = entity.Login,
                Email = entity.Email
            });
        }
        [HttpPut("Update")]
        public void Update(string id,UserDto entity)
        {
            _userServices.Update(new User
            {
                Id = entity.Id,
                Login = entity.Login,
                Email = entity.Email
            });
        }
        [HttpDelete("Delete")]
        public void Delete(string id)
        {
            _userServices.Delete(id);
        }
    }
}