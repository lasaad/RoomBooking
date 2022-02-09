using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Services;
using TestModel = RoomBooking.Domain.Models.Test;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class TestServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Tests()
        {
            var testRepository = Substitute.For<ITestRepository>();
            testRepository.GetTestsAsync().Returns(new List<TestModel>
            {
                new TestModel()
            });

            var service = new TestService(testRepository);
            var result = await service.GetTestsAsync();

            Assert.IsNotNull(result);
        }
    }
}
