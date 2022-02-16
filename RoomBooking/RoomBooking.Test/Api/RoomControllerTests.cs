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
    public class RoomControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Rooms()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoomsAsync().Returns(new List<Room>
            {
                new Room()
            });

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.GetRooms();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Get_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoomAsync(0).Returns(new Room());

            RoomController controller = new (roomService);
            IActionResult response = await controller.GetRoom(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoomAsync(0).Returns(new Room());

            RoomController controller = new (roomService);
            IActionResult response = await controller.EditRoom(new Room());

            Assert.IsNotNull(response);
            //Assert.IsInstanceOfType(response, typeof(ObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoomAsync(0).Returns(new Room());

            RoomController controller = new (roomService);
            IActionResult response = await controller.AddRoom(new Room());

            Assert.IsNotNull(response);
            //Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoomAsync(0).Returns(new Room());

            RoomController controller = new (roomService);
            IActionResult response = await controller.DeleteRoom(0);

            Assert.IsNotNull(response);
            //Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
