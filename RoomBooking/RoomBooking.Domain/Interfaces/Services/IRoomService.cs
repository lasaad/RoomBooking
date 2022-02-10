﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> GetRoomsAsync();
        Task<Room> GetRoomAsync(int id);
        Task<int> EditRoomsAsync(Room room);
        Task<int> AddRoomsAsync(Room room);
        Task<int> DeleteRoomsAsync();
    }
}
