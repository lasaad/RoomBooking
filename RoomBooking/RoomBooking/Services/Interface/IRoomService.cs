using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IRoomService
    {
        public Task<int> AddRoom(RoomEntity booking);
        public Task<RoomEntity> GetRoom(int id);
        public Task<List<RoomEntity>> GetRooms();
        public Task<int> DeleteRoom(int id);
        public Task<int> EditRoom(RoomEntity booking);
    }
}
