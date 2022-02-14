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

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<int> AddBookingAsync(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> DeleteBookingAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> EditBookingAsync(Booking booking)
        {
            throw new System.NotImplementedException();
        }

        public Task<Booking> GetBookingAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _bookingRepository.GetBookingsAsync();
        }

        
    }
}
