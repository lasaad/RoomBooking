using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IRoomService
    {
        public Task<int> AddRoom(Room booking);
        public Task<Room> GetRoom(int id);
        public Task<int> DeleteRoom(int id);
        public Task<int> EditRoom(Room booking);
    }
}
