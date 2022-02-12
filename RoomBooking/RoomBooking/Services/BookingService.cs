using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;

namespace RoomBooking.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingDataAccess dataAccess;
        public BookingService(IBookingDataAccess bookingDataAccess)
        {
            dataAccess = bookingDataAccess; 
        }

        public async Task<int> AddBooking(BookingEntity booking)
        {
            //var bookingExisted = dataAccess.()

            return await dataAccess.AddBooking(booking).ConfigureAwait(false);
        }

        public async Task<BookingEntity> GetBooking(int id)
        {
            return await dataAccess.GetBooking(id).ConfigureAwait(false);
        }

        public async Task<List<BookingEntity>> GetBookings()
        {
            return await dataAccess.GetBookings().ConfigureAwait(false);
        }

        public async Task<int> DeleteBooking(int id)
        {
            return await dataAccess.DeleteBooking(id).ConfigureAwait(false);
        }

        public async Task<int> EditBooking(BookingEntity booking)
        {
            return await dataAccess.EditBooking(booking).ConfigureAwait(false);
        }
    }
}
