using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Controllers;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Controllers;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomRoom.Controllers;
using IRoomService = RoomBooking.Api.Services.Interface.IRoomService;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class RoomControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Rooms()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRooms().Returns(new List<RoomEntity>
            {
                new RoomEntity()
            });

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.Get(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Get_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoom(0).Returns(new RoomEntity());

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.Get(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoom(0).Returns(new RoomEntity());

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.EditRoom(new RoomEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoom(0).Returns(new RoomEntity());

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.AddRoom(new RoomEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_Room()
        {
            IRoomService roomService = Substitute.For<IRoomService>();
            roomService.GetRoom(0).Returns(new RoomEntity());

            RoomController controller = new RoomController(roomService);
            IActionResult response = await controller.DeleteRoom(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
