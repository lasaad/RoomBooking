using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Controllers;
using RoomBooking.Controllers;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Users()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUsersAsync().Returns(new List<User>
            {
                new User()
            });

            UserController controller = new UserController(userService);
            IActionResult response = await controller.Get();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Get_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUserAsync(0).Returns(new User());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.GetById(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUserAsync(0).Returns(new User());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.EditUser(new User());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUserAsync(0).Returns(new User());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.AddUser(new User());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUserAsync(0).Returns(new User());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.DeleteUser(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
