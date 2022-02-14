using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using BookingService = RoomBooking.Api.Services.BookingService;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class BookingServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Bookings()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.GetBookingsAsync().Returns(new List<Booking> { new Booking()});

            var service = new BookingService(bookingRepository);
            var result = await service.GetBookingsAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Get_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.GetBookingAsync(0).Returns(new Booking());

            var service = new BookingService(bookingRepository);
            var result = await service.GetBookingAsync(0);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task Should_Edit_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.EditBookingsAsync(new Booking()).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.EditBookingAsync(new Booking());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Create_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.Equals(result, 1);
        }

        [TestMethod]
        public async Task Should_Delete_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.DeleteBookingAsync(0).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.DeleteBookingAsync(0);

            Assert.Equals(result, 1);
        }
    }
}
