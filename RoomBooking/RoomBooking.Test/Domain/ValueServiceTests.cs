using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;
using RoomBooking.Domain.Services;

namespace RoomBooking.Test.Domain
{
    [TestClass]
    public class ValueServiceTests
    {
        [TestMethod]
        public async Task Should_Get_Tests()
        {
            var testRepository = Substitute.For<IValueRepository>();
            testRepository.GetValuesAsync().Returns(new List<Value>
            {
                new Value()
            });

            var service = new ValueService(testRepository);
            var result = await service.GetValuesAsync();

            Assert.IsNotNull(result);
        }
    }
}
