using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Repositories
{
    public interface ITestRepository
    {
        Task<IEnumerable<Test>> GetTestsAsync();
    }
}
