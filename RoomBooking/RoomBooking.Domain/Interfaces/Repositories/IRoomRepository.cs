using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> GetRoomAsync(int id);
        Task<int> EditRoomAsync(Room room);
        Task<int> AddRoomAsync(Room room);
        Task<int> DeleteRoomAsync(int id);
    }
}
