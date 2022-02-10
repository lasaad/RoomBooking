using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
using System.Data.Entity;

namespace RoomBooking.Dal.DataAccess
{
    public class RoomDataAccess : IRoomDataAccess
    {
        private readonly KataHotelContext _context;

        public RoomDataAccess(KataHotelContext context)
        {
            _context = context; 
        }
        
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }
        
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room).ConfigureAwait(false);
            return _context.SaveChanges();
        }

        public async Task<int> EditRoom(Room room)
        {
            Room roomToEdit = await _context.Rooms.Where(b => b.Id == room.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (roomToEdit != null)
                roomToEdit = room;

            return _context.SaveChanges();
        }

        public async Task<int> DeleteRoom(int id)
        {
            Room roomToDelete = await _context.Rooms.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (roomToDelete != null)
                _context.Rooms.Remove(roomToDelete);

            return _context.SaveChanges();
        }
    }
}
