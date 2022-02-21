using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using BookingService = RoomBooking.Domain.Services.BookingService;
using System.Linq;

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
        public async Task Should_Create_Booking_Ok()
        {
            List<int> availableSlotsExpected = null;
            BookingResponse expected = new BookingResponse { IsAvailable = true, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(expected.AvailableHours, result.AvailableHours);
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
        }

        [TestMethod]
        [Ignore]
        public async Task Should_GetAvailableSlot_OneBookingInDay_FirstHour()
        {
            List<int> availableSlotsExpected = new List<int> { 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            BookingResponse expected = new BookingResponse { IsAvailable = true, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(expected.AvailableHours, result.AvailableHours);
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
        }

        [TestMethod]
        [Ignore]
        public async Task Should_GetAvailableSlot_OneBookingInDay_LastHour()
        {
            List<int> availableSlotsExpected = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
            BookingResponse expected = new BookingResponse { IsAvailable = true, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(expected.AvailableHours, result.AvailableHours);
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
        }

        [TestMethod]
        public async Task Should_GetAvailableSlot_OneBookingInDayOneHour()
        {
            List<int> availableSlotsExpected = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23};
            BookingResponse expected = new BookingResponse { IsAvailable = false, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);
            bookingRepository.GetBookingsByRoomAndDayAsync(default, default).Returns(new List<Booking> { new Booking() { StartSlot = 12, EndSlot = 0 }});

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking() { StartSlot = 12});

            Assert.AreEqual(true, expected.AvailableHours.SequenceEqual(result.AvailableHours));
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
        }

        [TestMethod]
        [Ignore]
        public async Task Should_GetAvailableSlot_OneBookingInDayTwoHour()
        {
            List<int> availableSlotsExpected = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };
            BookingResponse expected = new BookingResponse { IsAvailable = true, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(expected.AvailableHours, result.AvailableHours);
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
        }

        [TestMethod]
        [Ignore]
        public async Task Should_GetAvailableSlot_MultipleBookingDay()
        {
            List<int> availableSlotsExpected = new List<int> { 0, 1, 2, 3, 4, 5, 8, 9, 10, 11, 13, 14, 15, 16, 17, 18, 22, 23 };
            BookingResponse expected = new BookingResponse { IsAvailable = true, AvailableHours = availableSlotsExpected };

            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.AddBookingsAsync(new Booking()).Returns(0);

            var service = new BookingService(bookingRepository);
            var result = await service.AddBookingAsync(new Booking());

            Assert.AreEqual(expected.AvailableHours, result.AvailableHours);
            Assert.AreEqual(expected.IsAvailable, result.IsAvailable);
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
        [Ignore]
        public async Task Should_Return_Available_Slot()
        {
            //Arrange
            List<Booking> bookings = new List<Booking>();
            bookings.Add(new Booking() { Date = new DateTime(2022, 2, 18), StartSlot = 1, EndSlot = 3, RoomId = 1 });
            bookings.Add(new Booking() { Date = new DateTime(2022, 2, 18), StartSlot = 5, EndSlot = 6, RoomId = 1 });
            bookings.Add(new Booking() { Date = new DateTime(2022, 2, 18), StartSlot = 7, EndSlot = 8, RoomId = 1 });
            bookings.Add(new Booking() { Date = new DateTime(2022, 2, 18), StartSlot = 15, EndSlot = 20, RoomId = 1 });

            //Faire test sur domaine tout recuperer 
            var bookingRepository = Substitute.For<IBookingRepository>();
            bookingRepository.GetBookingsByRoomAndDayAsync(DateTime.Now, 1).ReturnsForAnyArgs(bookings);

            //Act
            var service = new BookingService(bookingRepository);
            var result = await service.GetAvailableSlot(DateTime.Now, 1);
            var expectedResult = new List<(int, int)> { (0, 1), (3, 5), (6, 7), (8, 15), (21,24) };
            //Assert
            Assert.AreEqual(result, 1);
        }
    }
}
