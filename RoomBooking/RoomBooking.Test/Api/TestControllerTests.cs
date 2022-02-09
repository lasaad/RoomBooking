using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Api.Controllers;
using RoomBooking.Domain.Interfaces.Services;
using TestModel = RoomBooking.Domain.Models.Test;

namespace RoomBooking.Test.Api
{
    [TestClass]
    public class TestControllerTests
    {
        [TestMethod]
        public async Task Should_Get_Tests()
        {
            var testService = Substitute.For<ITestService>();
            testService.GetTestsAsync().Returns(new List<TestModel>
            {
                new TestModel()
            });

            var controller = new TestController(testService);
            var response = await controller.GetTestsAsync();

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType(response, typeof(OkObjectResult));
        }
    }
}
