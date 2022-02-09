using RoomBooking.Dal.Models;
using RoomBooking.Domain.Models;
using System.Threading.Tasks;

namespace RoomBooking.Dal.Interfaces
{
    public interface IBookingDataAccess
    {
        public Task<int> AddBooking(Booking booking);
        public Task<int> EditBooking(Booking booking);
        public Task<int> DeleteBooking(int id);
        public Task<Booking> GetBooking(int id);
    }
}
