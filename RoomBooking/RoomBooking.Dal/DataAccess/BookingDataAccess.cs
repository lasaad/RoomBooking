

using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;

namespace RoomBooking.Dal.DataAccess
{
    public class BookingDataAccess : IBookingDataAccess
    {
        private readonly KataHotelContext _context;

        public BookingDataAccess(KataHotelContext context)
        {
            _context = context; 
        }
        
        public async Task<BookingEntity> GetBooking(int id)
        {
            return await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsAvailable(int startSlot, int endSlot, int roomId, DateTime date)
        {
            return await _context.Bookings.Where(b => b.Date == date && b.RoomId == roomId && b.StartSlot == startSlot && b.EndSlot == endSlot).AnyAsync().ConfigureAwait(false);
        }

        public async Task<List<BookingEntity>> AvailableBookOfDay(DateTime date)
        {
            return await _context.Bookings.Where(b => b.Date == date).ToListAsync().ConfigureAwait(false);

        }

        public async Task<int> AddBooking(BookingEntity booking)
        {
            await _context.Bookings.AddAsync(booking).ConfigureAwait(false);
            return _context.SaveChanges();
        }

        public async Task<int> EditBooking(BookingEntity booking)
        {
            BookingEntity bookingToEdit = await _context.Bookings.Where(b => b.Id == booking.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (bookingToEdit != null)
                bookingToEdit = booking;

            return _context.SaveChanges();
        }

        public async Task<int> DeleteBooking(int id)
        {
            BookingEntity bookingToDelete = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (bookingToDelete != null)
                _context.Bookings.Remove(bookingToDelete);

            return _context.SaveChanges();
        }

        public async Task<List<BookingEntity>> GetBookings()
        {
            return await _context.Bookings.ToListAsync().ConfigureAwait(false);
        }
    }
}
