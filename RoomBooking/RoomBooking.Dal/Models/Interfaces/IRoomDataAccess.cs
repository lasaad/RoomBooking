using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IRoomDataAccess
    {
        public Task<Room> GetBooking(int id);

        public Task<int> AddRoom(Room room);

        public Task<int> EditRoom(Room room);

        public Task<int> DeleteRoom(int id);
    }
}