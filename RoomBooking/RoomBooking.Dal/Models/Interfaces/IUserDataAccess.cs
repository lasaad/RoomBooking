using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IUserDataAccess
    {
        public Task<int> AddUser(User booking);

        public Task<int> EditUser(User booking);

        public Task<int> DeleteUser(int id);
    }
}
