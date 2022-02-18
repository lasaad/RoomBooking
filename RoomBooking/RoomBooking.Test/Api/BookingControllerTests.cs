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
using Serilog;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class BookingControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Bookings()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            ILogger loggerService = Substitute.For<ILogger>();
            bookingService.GetBookingsAsync().Returns(new List<Booking>
            {
                new Booking()
            });

            BookingController controller = new BookingController(bookingService, loggerService);
            IActionResult response = await controller.GetBooking(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Get_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            ILogger loggerService = Substitute.For<ILogger>();

            bookingService.GetBookingAsync(0).Returns(new Booking());

            BookingController controller = new BookingController(bookingService, loggerService);
            IActionResult response = await controller.GetBooking(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Edit_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            ILogger loggerService = Substitute.For<ILogger>();

            bookingService.GetBookingAsync(0).Returns(new Booking());

            BookingController controller = new BookingController(bookingService, loggerService);
            IActionResult response = await controller.EditBooking(new Booking());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Create_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            ILogger loggerService = Substitute.For<ILogger>();

            bookingService.GetBookingAsync(0).Returns(new Booking());

            BookingController controller = new BookingController(bookingService, loggerService);
            IActionResult response = await controller.AddBooking(new Booking());

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task Should_Delete_Booking()
        {
            IBookingService bookingService = Substitute.For<IBookingService>();
            ILogger loggerService = Substitute.For<ILogger>();

            bookingService.GetBookingAsync(0).Returns(new Booking());

            BookingController controller = new BookingController(bookingService, loggerService);
            IActionResult response = await controller.DeleteBooking(0);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
