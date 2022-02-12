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
using IBookingService = RoomBooking.Api.Services.Interface.IBookingService;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class BookingControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Bookings()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            bookingService.GetBookings().Returns(new List<BookingEntity>
            {
                new BookingEntity()
            });

            BookingController controller = new BookingController(bookingService);
            IActionResult response = await controller.Get(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Get_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            bookingService.GetBooking(0).Returns(new BookingEntity());

            BookingController controller = new BookingController(bookingService);
            IActionResult response = await controller.Get(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            bookingService.GetBooking(0).Returns(new BookingEntity());

            BookingController controller = new BookingController(bookingService);
            IActionResult response = await controller.EditBooking(new BookingEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            bookingService.GetBooking(0).Returns(new BookingEntity());

            BookingController controller = new BookingController(bookingService);
            IActionResult response = await controller.AddBooking(new BookingEntity());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            bookingService.GetBooking(0).Returns(new BookingEntity());

            BookingController controller = new BookingController(bookingService);
            IActionResult response = await controller.DeleteBooking(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
