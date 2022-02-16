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

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            return await _roomRepository.AddRoomAsync(room);
        }

        public async Task<int> DeleteRoomAsync(int id)
        {
            return await _roomRepository.DeleteRoomAsync(id);
        }

        public async Task<int> EditRoomAsync(Room room)
        {
            return await _roomRepository.EditRoomAsync(room);
        }

        public async Task<Room> GetRoomAsync(int id)
        {
            return await _roomRepository.GetRoomAsync(id);
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync()
        {
            return await _roomRepository.GetRoomsAsync();
        }
    }
}
