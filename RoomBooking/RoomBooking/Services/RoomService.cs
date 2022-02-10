﻿using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomDataAccess dataAccess;
        public RoomService(IRoomDataAccess bookingDataAccess)
        {
            dataAccess = bookingDataAccess;
        }

        public async Task<int> AddRoom(Room room)
        {
            return await dataAccess.AddRoom(room).ConfigureAwait(false);
        }

        public async Task<Room> GetRoom(int id)
        {
            return await dataAccess.GetRoom(id).ConfigureAwait(false);
        }
        
        public async Task<List<Room>> GetRooms()
        {
            return await dataAccess.GetRooms().ConfigureAwait(false);
        }

        public async Task<int> DeleteRoom(int id)
        {
            return await dataAccess.DeleteRoom(id).ConfigureAwait(false);
        }

        public async Task<int> EditRoom(Room booking)
        {
            return await dataAccess.EditRoom(booking).ConfigureAwait(false);
        }

    }
}
