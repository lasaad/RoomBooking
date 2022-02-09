using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository) =>
            _testRepository = testRepository;

        public async Task<IEnumerable<Test>> GetTestsAsync() =>
            await _testRepository.GetTestsAsync();
    }
}
