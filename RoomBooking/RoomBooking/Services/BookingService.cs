using RoomBooking.Dal.Models;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Api.Services.Interface;

namespace RoomBooking.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDataAccess dataAccess;
        public BookingService(IBookingDataAccess bookingDataAccess)
        {
            dataAccess = bookingDataAccess; 
        }

        public int AddBooking(Booking booking)
        {
            //Booking booking = new ()
            //{
            //    StartSlot = 0,
            //    EndSlot = 0,
            //    Date = DateTime.Now,
            //    RoomId = 1,
            //    UserId = 1
            //};

            return dataAccess.AddBooking(booking);
        }

        public Booking GetBooking(int id)
        {
            return dataAccess.GetBooking(id);
        }

        public int DeleteBooking(int id)
        {
            return dataAccess.DeleteBooking(id);
        }

        public int EditBooking(Booking booking)
        {
            return dataAccess.EditBooking(booking);
        }
    }
}
