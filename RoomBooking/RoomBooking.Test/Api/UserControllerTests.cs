using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Controllers;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomRoom.Controllers;
using IUserService = RoomBooking.Api.Services.Interface.IUserService;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class UserControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Users()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUsers().Returns(new List<UserEntity>
            {
                new UserEntity()
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
            userService.GetUser(0).Returns(new UserEntity());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.Get(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUser(0).Returns(new UserEntity());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.EditUser(new UserEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUser(0).Returns(new UserEntity());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.AddUser(new UserEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_User()
        {
            IUserService userService = Substitute.For<IUserService>();
            userService.GetUser(0).Returns(new UserEntity());

            UserController controller = new UserController(userService);
            IActionResult response = await controller.DeleteUser(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
