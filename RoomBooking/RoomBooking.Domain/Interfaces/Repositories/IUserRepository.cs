using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<int> EditUserAsync(User user);
        Task<int> AddUserAsync(User user);
        Task<int> DeleteUserAsync(int id);
    }
}
