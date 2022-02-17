using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using BookingService = RoomBooking.Domain.Services.BookingService;

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
            bookingRepository.EditBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.EditBookingAsync(new Booking());

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public async Task Should_Create_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public async Task Should_Delete_Booking()
        {
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.DeleteBookingAsync(0).Returns(1);

            var service = new BookingService(bookingRepository);
            var result = await service.DeleteBookingAsync(0);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public async Task Should_Return_Available_Slot()
        {
            //Arrange
            List<Booking> bookings = new List<Booking>();
            bookings.Add(new Booking() { Date = DateTime.Now, StartSlot = 1, EndSlot = 3, RoomId = 1 });
            bookings.Add(new Booking() { Date = DateTime.Now, StartSlot = 5, EndSlot = 6, RoomId = 1 });
            bookings.Add(new Booking() { Date = DateTime.Now, StartSlot = 7, EndSlot = 8, RoomId = 1 });
            bookings.Add(new Booking() { Date = DateTime.Now.AddDays(1), StartSlot = 1, EndSlot = 3, RoomId = 1 });
            bookings.Add(new Booking() { Date = DateTime.Now, StartSlot = 1, EndSlot = 3, RoomId = 2 });

            //Faire test sur domaine tout recuperer 
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.GetBookingsAsync().Returns(bookings);

            //Act
            var service = new BookingService(bookingRepository);
            var result = await service.GetAvailableSlot(DateTime.Now, 1);

            //Assert
            Assert.AreEqual(result, 1);
        }
    }
}
