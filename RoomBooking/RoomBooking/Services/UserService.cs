using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
namespace UserBooking.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserDataAccess dataAccess;
        public UserService(IUserDataAccess bookingDataAccess)
        {
            dataAccess = bookingDataAccess;
        }

        public async Task<int> AddUser(User user)
        {
            return await dataAccess.AddUser(user).ConfigureAwait(false);
        }

        public async Task<User> GetUser(int id)
        {
            return await dataAccess.GetUser(id).ConfigureAwait(false);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await dataAccess.DeleteUser(id).ConfigureAwait(false);
        }

        public async Task<int> EditUser(User booking)
        {
            return await dataAccess.EditUser(booking).ConfigureAwait(false);
        }

    }
}
