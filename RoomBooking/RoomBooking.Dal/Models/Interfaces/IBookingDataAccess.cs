using RoomBooking.Dal.Models;
using System.Threading.Tasks;

namespace RoomBooking.Dal.Interfaces
{
    public interface IBookingDataAccess
    {
        Task<int> AddBooking(Booking booking);
        Task<int> EditBooking(Booking booking);
        Task<int> DeleteBooking(int id);
        Task<Booking> GetBooking(int id);
    }
}
