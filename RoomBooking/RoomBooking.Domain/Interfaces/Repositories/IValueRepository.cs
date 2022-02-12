using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Repositories
{
    public interface IValueRepository
    {
        Task<IEnumerable<Value>> GetValuesAsync();
    }
}
