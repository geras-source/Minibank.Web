using Microsoft.AspNetCore.Mvc;
using Minibank.Core;
using Minibank.Core.Domains.Users;
using Minibank.Core.Domains.Users.Services;
using Minibank.Web.Controllers;
using Minibank.Web.Controllers.Users;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Minibank.Tests
{
    public class ControllerTests
    {
        [Fact]
        public async Task CountUsers()
        {
            // Arrange
            var mock = new Mock<IUserServices>();
            mock.Setup(repo => repo.GetUsersAsync().Result).Returns(GetTestUsers());
            
            //Act
            var result = await mock.Object.GetUsersAsync();
            
            // Assert
            Assert.Equal(GetTestUsers().ToList().Count, result.ToList().Count);
        }
        [Fact]
        public async Task Data()
        {
            // Arrange
            var userTest = new User() { Id = 10, Email = "asd", Login = "qwe"};
            var mock = new Mock<IUserServices>();
            mock.Setup(repo => repo.GetAsync(10).Result).Returns(userTest);
            var controller = new UserController(mock.Object);

            //Act
            var result = await controller.GetAsync(10);
            var entity = new User
            {
                Id = result.Id,
                Login = result.Login,
                Email = result.Email
            };

            // Assert
            Assert.Equal(userTest.Id, entity.Id);
        }
        private IEnumerable<User> GetTestUsers()
        {
            var users = new List<User>
            {
               new User {Id = 10, Email = "", Login = ""},
               new User {Id = 10, Email = "", Login = ""}
            };
            return users;
        }
    }   
}
