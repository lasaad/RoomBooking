using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services.Interface
{
    public interface IBookingService
    {
        public int AddBooking(Booking booking);

        public Booking GetBooking(int id);

        public int DeleteBooking(int id);

        public int EditBooking(Booking booking);
    }
}
