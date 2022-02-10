using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<int> EditUsersAsync(User user);
        Task<int> AddUsersAsync(User user);
        Task<int> DeleteUsersAsync();
    }
}
