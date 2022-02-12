using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class ValueService : IValueService
    {
        private readonly IValueRepository _testRepository;

        public ValueService(IValueRepository testRepository) =>
            _testRepository = testRepository;

        public async Task<IEnumerable<Value>> GetValuesAsync() =>
            await _testRepository.GetValuesAsync();
    }
}
