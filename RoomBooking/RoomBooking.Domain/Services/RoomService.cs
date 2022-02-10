using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository) =>
            _roomRepository = roomRepository;

        public Task<int> AddRoomsAsync(Room room)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteRoomsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditRoomsAsync(Room room)
        {
            throw new System.NotImplementedException();
        }

        public Task<Room> GetRoomAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync() =>
            await _roomRepository.GetRoomsAsync();
    }
}
