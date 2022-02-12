using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess dataAccess;
        public UserService(IUserDataAccess bookingDataAccess)
        {
            dataAccess = bookingDataAccess;
        }

        public async Task<int> AddUser(UserEntity user)
        {
            return await dataAccess.AddUser(user).ConfigureAwait(false);
        }

        public async Task<UserEntity> GetUser(int id)
        {
            return await dataAccess.GetUser(id).ConfigureAwait(false);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await dataAccess.DeleteUser(id).ConfigureAwait(false);
        }

        public async Task<int> EditUser(UserEntity booking)
        {
            return await dataAccess.EditUser(booking).ConfigureAwait(false);
        }

        public async Task<List<UserEntity>> GetUsers()
        {
            return await dataAccess.GetUsers().ConfigureAwait(false);
        }

    }
}
