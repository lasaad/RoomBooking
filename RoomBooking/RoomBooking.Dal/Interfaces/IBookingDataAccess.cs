using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.Interfaces
{
    public interface IBookingDataAccess
    {
        public int AddBooking(Booking booking);

        public int EditBooking(Booking booking);

        public int DeleteBooking(int id);

        public Booking GetBooking(int id);
    }
}
