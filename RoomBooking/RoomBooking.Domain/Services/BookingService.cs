using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository) =>
            _bookingRepository = bookingRepository;

        public async Task<IEnumerable<Booking>> GetBookingsAsync() =>
            await _bookingRepository.GetBookingsAsync();

        public async Task<IEnumerable<Booking>> DeleteBookingAsync(int id) =>
            await _bookingRepository.GetBookingsAsync();

        public Task<Booking> GetBookingAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditBookingsAsync(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> AddBookingsAsync(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteBookingsAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<List<Booking>> IBookingService.GetBookingsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
