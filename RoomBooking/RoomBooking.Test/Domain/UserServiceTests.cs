using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;
using RoomBooking.Domain.Services;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Users()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUsersAsync().Returns(new List<User> { new User()});

            var service = new UserService(userRepository);
            var result = await service.GetUsersAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_User()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.GetUserAsync(0).Returns(new User());

            var service = new UserService(userRepository);
            var result = await service.GetUserAsync(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_User()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.EditUserAsync(new User()).Returns(0);

            var service = new UserService(userRepository);
            var result = await service.EditUserAsync(new User());

            Assert.Equals(result, 0);
        }

        [TestMethod]
        public async Task Should_Create_User()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.AddUserAsync(new User()).Returns(0);

            var service = new UserService(userRepository);
            var result = await service.AddUserAsync(new User());

            Assert.Equals(result, 0);
        }

        [TestMethod]
        public async Task Should_Delete_User()
        {
            var userRepository = Substitute.For<IUserRepository>();
            userRepository.DeleteUserAsync(0).Returns(1);

            var service = new UserService(userRepository);
            var result = await service.DeleteUserAsync(0);

            Assert.Equals(result, 0);
        }
    }
}
