using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
using UserService = RoomBooking.Api.Services.UserService;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Users()
        {
            var userRepository = Substitute.For<IUserDataAccess>();
            userRepository.GetUsers().Returns(new List<UserEntity> { new UserEntity()});

            var service = new UserService(userRepository);
            var result = await service.GetUsers();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_User()
        {
            var userRepository = Substitute.For<IUserDataAccess>();
            userRepository.GetUser(0).Returns(new UserEntity());

            var service = new UserService(userRepository);
            var result = await service.GetUser(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_User()
        {
            var userRepository = Substitute.For<IUserDataAccess>();
            userRepository.EditUser(new UserEntity()).Returns(1);

            var service = new UserService(userRepository);
            var result = await service.EditUser(new UserEntity());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Create_User()
        {
            var userRepository = Substitute.For<IUserDataAccess>();
            userRepository.AddUser(new UserEntity()).Returns(1);

            var service = new UserService(userRepository);
            var result = await service.AddUser(new UserEntity());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Delete_User()
        {
            var userRepository = Substitute.For<IUserDataAccess>();
            userRepository.DeleteUser(0).Returns(1);

            var service = new UserService(userRepository);
            var result = await service.DeleteUser(0);

            Assert.Equals(result, 1);
        }
    }
}
