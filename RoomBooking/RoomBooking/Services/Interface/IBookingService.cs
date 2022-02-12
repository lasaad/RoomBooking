using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IBookingService
    {
        public Task<int> AddBooking(BookingEntity booking);

        public Task<BookingEntity> GetBooking(int id);
        public Task<List<BookingEntity>> GetBookings();

        public Task<int> DeleteBooking(int id);

        public Task<int> EditBooking(BookingEntity booking);
    }
}
