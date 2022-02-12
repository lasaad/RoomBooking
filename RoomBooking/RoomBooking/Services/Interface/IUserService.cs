using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IUserService
    {
        public Task<int> AddUser(UserEntity booking);
        public Task<UserEntity> GetUser(int id);
        public Task<int> DeleteUser(int id);
        public Task<int> EditUser(UserEntity booking);
        public Task<List<UserEntity>> GetUsers();
    }
}
