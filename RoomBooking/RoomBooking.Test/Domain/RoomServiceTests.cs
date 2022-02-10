using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Services;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Services;
using RoomDto = RoomBooking.Dal.Models.Room;
using RoomService = RoomBooking.Api.Services.RoomService;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class RoomServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Rooms()
        {
            var roomRepository = Substitute.For<IRoomDataAccess>();
            roomRepository.GetRooms().Returns(new List<Room> { new Room()});

            var service = new RoomService(roomRepository);
            var result = await service.GetRooms();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_Room()
        {
            var roomRepository = Substitute.For<IRoomDataAccess>();
            roomRepository.GetRoom(0).Returns(new Room());

            var service = new RoomService(roomRepository);
            var result = await service.GetRoom(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_Room()
        {
            var roomRepository = Substitute.For<IRoomDataAccess>();
            roomRepository.EditRoom(new Room()).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.EditRoom(new Room());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Create_Room()
        {
            var roomRepository = Substitute.For<IRoomDataAccess>();
            roomRepository.AddRoom(new Room()).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.AddRoom(new Room());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Delete_Room()
        {
            var roomRepository = Substitute.For<IRoomDataAccess>();
            roomRepository.DeleteRoom(0).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.DeleteRoom(0);

            Assert.Equals(result, 1);
        }
    }
}
