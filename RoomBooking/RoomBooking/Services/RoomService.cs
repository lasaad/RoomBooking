using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Api.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository dataAccess;
        public RoomService(IRoomRepository bookingDataAccess)
        {
            dataAccess = bookingDataAccess;
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            return await dataAccess.AddRoomAsync(room).ConfigureAwait(false);
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            return await dataAccess.GetRoomAsync(id).ConfigureAwait(false);
        }
        
        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await dataAccess.GetRoomsAsync().ConfigureAwait(false);
        }

        public async Task<int> DeleteRoomAsync(int id)
        {
            return await dataAccess.DeleteRoomAsync(id).ConfigureAwait(false);
        }

        public async Task<int> EditRoomAsync(Room room)
        {
            return await dataAccess.EditRoomAsync(room).ConfigureAwait(false);
        }
    }
}
