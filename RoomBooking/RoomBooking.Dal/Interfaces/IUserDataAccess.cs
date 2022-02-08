using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IUserDataAccess
    {
        public int AddUser(User booking);

        public int EditUser(User booking);

        public int DeleteUser(int id);
    }
}
