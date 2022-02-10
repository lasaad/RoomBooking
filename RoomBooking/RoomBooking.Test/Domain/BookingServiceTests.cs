using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Services;
using Booking = RoomBooking.Dal.Models.Booking;
using BookingService = RoomBooking.Api.Services.BookingService;
using RoomBooking.Api.Services;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class BookingServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Bookings()
        {
            var bookingRepository = Substitute.For<IBookingDataAccess>();
            bookingRepository.GetBookings().Returns(new List<Booking> { new Booking()});

            var service = new BookingService(bookingRepository);
            var result = await service.GetBookings();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_Booking()
        {
            var bookingRepository = Substitute.For<IBookingDataAccess>();
            bookingRepository.GetBooking(0).Returns(new Booking());

            var service = new BookingService(bookingRepository);
            var result = await service.GetBooking(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_Booking()
        {
            var bookingRepository = Substitute.For<IBookingDataAccess>();
            bookingRepository.EditBooking(new Booking()).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.EditBooking(new Booking());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Create_Booking()
        {
            var bookingRepository = Substitute.For<IBookingDataAccess>();
            bookingRepository.AddBooking(new Booking()).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBooking(new Booking());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Delete_Booking()
        {
            var bookingRepository = Substitute.For<IBookingDataAccess>();
            bookingRepository.DeleteBooking(0).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.DeleteBooking(0);

            Assert.Equals(result, 1);
        }
    }
}
