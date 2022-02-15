using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByRoomAndDayAsync(DateTime day, int roomId);
        Task<int> EditBookingsAsync(Booking booking);
        Task<int> AddBookingsAsync(Booking booking);
        Task<int> DeleteBookingAsync(int id);
    }
}
