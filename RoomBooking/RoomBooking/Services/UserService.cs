using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository dataAccess;
        public UserService(IUserRepository bookingDataAccess)
        {
            dataAccess = bookingDataAccess;
        }

        public async Task<int> AddUserAsync(User user)
        {
            return await dataAccess.AddUsersAsync(user).ConfigureAwait(false);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await dataAccess.GetUserAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await dataAccess.GetUsersAsync().ConfigureAwait(false);
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            return await dataAccess.DeleteUserAsync(id).ConfigureAwait(false);
        }

        public async Task<int> EditUserAsync(User user)
        {
            return await dataAccess.EditUsersAsync(user).ConfigureAwait(false);
        }
    }
}
