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
    public class RoomValidationTest
    {
        [TestMethod]
        public void OkModelNumericName()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Room room = new()
            {
                Id = 0,
                Name = "Salle 1"
            };
            ValidationContext validationContext = new (room);

            //Act
            bool isValid = Validator.TryValidateObject(room, validationContext, errors, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void OkModelName()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Room room = new()
            {
                Id = 0,
                Name = "Salle Toto"
            };
            ValidationContext validationContext = new(room);

            //Act
            bool isValid = Validator.TryValidateObject(room, validationContext, errors, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PasDeMajuscule()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Room room = new()
            {
                Id = 0,
                Name = "salle Toto"
            };
            ValidationContext validationContext = new(room);

            //Act
            bool isValid = Validator.TryValidateObject(room, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CaractereSpecial()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Room room = new()
            {
                Id = 0,
                Name = "Salle-Toto"
            };
            ValidationContext validationContext = new(room);

            //Act
            bool isValid = Validator.TryValidateObject(room, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CaractereAccent()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            Room room = new()
            {
                Id = 0,
                Name = "Salle Tôto"
            };
            ValidationContext validationContext = new(room);

            //Act
            bool isValid = Validator.TryValidateObject(room, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }
    }
}
