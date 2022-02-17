using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Models;

namespace UserBooking.Test.Validation.Model
{
    [TestClass]
    public class UserValidationTest
    {
        private User GetTemplateUserTest()
        {
            return new User()
            {
                FirstName = "Jean",
                LastName = "Nom",
                Id = 0
            };
        }

        [TestMethod]
        public void NoNumber()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            User user = GetTemplateUserTest();
            user.LastName = "Dup0nt";
            ValidationContext validationContext = new(user);

            //Act
            bool isValid = Validator.TryValidateObject(user, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void OkModelName()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            User user = GetTemplateUserTest();
            user.LastName = "DUPONT MARTIN JOSÉ ÜNDIZ";
            ValidationContext validationContext = new(user);

            //Act
            bool isValid = Validator.TryValidateObject(user, validationContext, errors, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void PasDeMajusculeNom()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            User user = GetTemplateUserTest();
            user.LastName = "Dupont";

            ValidationContext validationContext = new(user);

            //Act
            bool isValid = Validator.TryValidateObject(user, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CaractereSpecialOk()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            User user = GetTemplateUserTest();
            user.LastName = "DUPONT MARTIN JOSÉ ÜNDIZ";

            ValidationContext validationContext = new(user);

            //Act
            bool isValid = Validator.TryValidateObject(user, validationContext, errors, true);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void CaractereAccent()
        {
            //Arrange
            ICollection<ValidationResult> errors = new List<ValidationResult>();
            User user = GetTemplateUserTest();
            user.LastName = "DUPONT-MARTIN_JOSÉ ÜNDIZ";
            
            ValidationContext validationContext = new(user);

            //Act
            bool isValid = Validator.TryValidateObject(user, validationContext, errors, true);

            //Assert
            Assert.IsFalse(isValid);
        }
    }
}
