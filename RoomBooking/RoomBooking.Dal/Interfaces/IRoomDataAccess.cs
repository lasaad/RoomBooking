using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IRoomDataAccess
    {
        public Room GetBooking(int id);

        public int AddRoom(Room room);

        public int EditRoom(Room room);

        public int DeleteRoom(int id);
    }
}