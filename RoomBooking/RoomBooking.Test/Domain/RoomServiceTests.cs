using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using RoomService = RoomBooking.Api.Services.RoomService;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class RoomServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Rooms()
        {
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.GetRoomsAsync().Returns(new List<Room> { new Room()});

            var service = new RoomService(roomRepository);
            var result = await service.GetRoomsAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_Room()
        {
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.GetRoomAsync(0).Returns(new Room());

            var service = new RoomService(roomRepository);
            var result = await service.GetRoomAsync(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_Room()
        {
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.EditRoomsAsync(new Room()).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.EditRoomAsync(new Room());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Create_Room()
        {
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.AddRoomsAsync(new Room()).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.AddRoomAsync(new Room());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Delete_Room()
        {
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.DeleteRoomAsync(0).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.DeleteRoomAsync(0);

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Return_Nouveau_Creneau()
        {
            //Faire test sur domaine tout recuperer 
            var roomRepository = Substitute.For<IRoomRepository>();
            roomRepository.DeleteRoomAsync(0).Returns(1);

            var service = new RoomService(roomRepository);
            var result = await service.DeleteRoomAsync(0);

            Assert.Equals(result, 1);
        }
    }
}
