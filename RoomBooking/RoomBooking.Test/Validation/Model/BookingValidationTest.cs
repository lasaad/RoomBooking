using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using BookingService = RoomBooking.Domain.Services.BookingService;

namespace RoomBooking.Test.Validation.Model
{
    [TestClass]
    public class BookingValidationTest
    {
        [TestMethod]
        public void OkModel()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Booking booking = new()
            {
                Date = DateTime.Now,
                StartSlot = 1,
                EndSlot = 2,
                Id = 0,
                RoomId = 0,
                UserId = 1
            };
            ValidationContext validationContext = new (booking);

            //Act
            bool isValid = Validator.TryValidateObject(booking, validationContext, errors, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void EndSlotToEarly()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Booking booking = new()
            {
                Date = DateTime.Now,
                StartSlot = 1,
                EndSlot = -1,
                Id = 0,
                RoomId = 0,
                UserId = 1
            };
            ValidationContext validationContext = new(booking);

            //Act
            bool isValid = Validator.TryValidateObject(booking, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StartSlotToEarly()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Booking booking = new()
            {
                Date = DateTime.Now,
                StartSlot = -1,
                EndSlot = 2,
                Id = 0,
                RoomId = 0,
                UserId = 1
            };
            ValidationContext validationContext = new(booking);

            //Act
            bool isValid = Validator.TryValidateObject(booking, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void EndSlotToLate()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Booking booking = new()
            {
                Date = DateTime.Now,
                StartSlot = 1,
                EndSlot = 24,
                Id = 0,
                RoomId = 0,
                UserId = 1
            };
            ValidationContext validationContext = new(booking);

            //Act
            bool isValid = Validator.TryValidateObject(booking, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void StartSlotToLate()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Booking booking = new()
            {
                Date = DateTime.Now,
                StartSlot = -1,
                EndSlot = 2,
                Id = 0,
                RoomId = 0,
                UserId = 1
            };
            ValidationContext validationContext = new(booking);

            //Act
            bool isValid = Validator.TryValidateObject(booking, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }
    }
}
