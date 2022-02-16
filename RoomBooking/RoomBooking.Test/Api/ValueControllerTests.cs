using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Controllers;
using RoomBooking.Domain.Interfaces.Services;
using TestModel = RoomBooking.Domain.Models.Value;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class ValueControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Tests()
        {
            var testService = Substitute.For<IValueService>();
            testService.GetValuesAsync().Returns(new List<TestModel>
            {
                new TestModel()
            });

            var controller = new ValueController(testService);
            var response = await controller.GetValuesAsync();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
