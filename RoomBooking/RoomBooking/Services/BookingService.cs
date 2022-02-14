using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository repository;
        public BookingService(IBookingRepository bookingRepository)
        {
            repository = bookingRepository; 
        }

        public async Task<int> AddBookingAsync(Booking booking)
        {
            return await repository.AddBookingsAsync(booking).ConfigureAwait(false);
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            return await repository.GetBookingAsync(id).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await repository.GetBookingsAsync().ConfigureAwait(false);
        }

        public async Task<int> DeleteBookingAsync(int id)
        {
            return await repository.DeleteBookingAsync(id).ConfigureAwait(false);
        }

        public async Task<int> EditBookingAsync(Booking booking)
        {
            return await repository.EditBookingsAsync(booking).ConfigureAwait(false);
        }
    }
}
