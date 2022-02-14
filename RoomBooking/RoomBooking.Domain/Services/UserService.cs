using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public Task<int> AddUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddUsersAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditUserAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditUsersAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync() =>
            await _userRepository.GetUsersAsync();
    }
}
