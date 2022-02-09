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

        public async Task<int> AddBooking(Booking booking)
        {
            return await dataAccess.AddBooking(booking).ConfigureAwait(false);
        }

        public async Task<Booking> GetBooking(int id)
        {
            return await dataAccess.GetBooking(id).ConfigureAwait(false);
        }

        public async Task<int> DeleteBooking(int id)
        {
            return await dataAccess.DeleteBooking(id).ConfigureAwait(false);
        }

        public async Task<int> EditBooking(Booking booking)
        {
            return await dataAccess.EditBooking(booking).ConfigureAwait(false);
        }
    }
}
