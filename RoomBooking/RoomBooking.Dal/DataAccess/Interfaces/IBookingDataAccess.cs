using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IBookingDataAccess
    {
        public Task<int> AddBooking(BookingEntity booking);
        public Task<int> EditBooking(BookingEntity booking);
        public Task<int> DeleteBooking(int id);
        public Task<BookingEntity> GetBooking(int id);
        public Task<List<BookingEntity>> GetBookings();
    }
}
