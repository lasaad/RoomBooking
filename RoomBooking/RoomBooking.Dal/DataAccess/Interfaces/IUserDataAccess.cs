using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IUserDataAccess
    {
        Task<int> AddUser(UserEntity booking);

        Task<int> EditUser(UserEntity booking);

        Task<int> DeleteUser(int id);

        Task<UserEntity> GetUser(int id);

        Task<List<UserEntity>> GetUsers();
    }
}
