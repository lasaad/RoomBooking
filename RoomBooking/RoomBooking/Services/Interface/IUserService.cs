using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IUserService
    {
        public Task<int> AddUser(User booking);
        public Task<User> GetUser(int id);
        public Task<int> DeleteUser(int id);
        public Task<int> EditUser(User booking);
        public Task<List<User>> GetUsers();
    }
}
