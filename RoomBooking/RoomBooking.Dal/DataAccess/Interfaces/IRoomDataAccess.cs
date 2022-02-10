using RoomBooking.Dal.Models;
using RoomBooking.Domain.Models;
using System.Threading.Tasks;
using Room = RoomBooking.Dal.Models.Room;

namespace RoomBooking.Dal.Interfaces
{
    public interface IRoomDataAccess
    {
        Task<List<Room>> GetRooms();
        Task<Room> GetRoom(int id);
        Task<int> AddRoom(Room room);
        Task<int> EditRoom(Room room);
        Task<int> DeleteRoom(int id);
    }
}