using RoomBooking.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Dal.Interfaces;


namespace RoomBooking.Dal.DataAccess
{
    public class RoomDataAccess : IRoomDataAccess
    {
        private readonly KataHotelContext _context;

        public RoomDataAccess(KataHotelContext context)
        {
            _context = context; 
        }
        
        public Room GetBooking(int id)
        {
            return _context.Rooms.Where(b => b.Id == id).FirstOrDefault();
        }

        public int AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            return _context.SaveChanges();
        }

        public int EditRoom(Room room)
        {
            Room roomToEdit = _context.Rooms.Where(b => b.Id == room.Id).FirstOrDefault();
            if (roomToEdit != null)
                roomToEdit = room;

            return _context.SaveChanges();
        }

        public int DeleteRoom(int id)
        {
            Room roomToDelete = _context.Rooms.Where(b => b.Id == id).FirstOrDefault();

            if (roomToDelete != null)
                _context.Rooms.Remove(roomToDelete);

            return _context.SaveChanges();
        }
    }
}
