using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IBookingService
    {
        public Task<int> AddBooking(Booking booking);

        public Task<Booking> GetBooking(int id);
        public Task<List<Booking>> GetBookings();

        public Task<int> DeleteBooking(int id);

        public Task<int> EditBooking(Booking booking);
    }
}
