using RoomBooking.Dal.Models;
using RoomBooking.Domain.Models;
using System.Threading.Tasks;

namespace RoomBooking.Dal.Interfaces
{
    public interface IUserDataAccess
    {
        Task<int> AddUser(User booking);

        Task<int> EditUser(User booking);

        Task<int> DeleteUser(int id);

        Task<User> GetUser(int id);

        Task<List<User>> GetUsers();
    }
}
