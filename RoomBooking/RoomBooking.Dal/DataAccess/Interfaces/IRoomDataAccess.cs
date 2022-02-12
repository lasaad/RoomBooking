using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IRoomDataAccess
    {
        Task<List<RoomEntity>> GetRooms();
        Task<RoomEntity> GetRoom(int id);
        Task<int> AddRoom(RoomEntity room);
        Task<int> EditRoom(RoomEntity room);
        Task<int> DeleteRoom(int id);
    }
}