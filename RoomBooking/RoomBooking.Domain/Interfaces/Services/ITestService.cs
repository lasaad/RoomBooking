using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Services
{
    public interface ITestService
    {
        Task<IEnumerable<Test>> GetTestsAsync();
    }
}
