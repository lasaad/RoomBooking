

using RoomBooking.Dal.Interfaces;
using RoomBooking.Dal.Models;
using System.Data.Entity;

namespace RoomBooking.Dal.DataAccess
{
    public class BookingDataAccess : IBookingDataAccess
    {
        private readonly KataHotelContext _context;

        public BookingDataAccess(KataHotelContext context)
        {
            _context = context; 
        }
        
        public async Task<Booking> GetBooking(int id)
        {
            return  await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsAvailable(int startSlot, int endSlot, int roomId, DateTime date)
        {
            return await _context.Bookings.Where(b => b.Date == date && b.RoomId == roomId && b.StartSlot == startSlot && b.EndSlot == endSlot).AnyAsync().ConfigureAwait(false);
        }

        public async Task<List<Booking>> AvailableBookOfDay(DateTime date)
        {
            return await _context.Bookings.Where(b => b.Date == date).ToListAsync().ConfigureAwait(false);

        }

        public async Task<int> AddBooking(Booking booking)
        {
            await _context.Bookings.AddAsync(booking).ConfigureAwait(false);
            return _context.SaveChanges();
        }

        public async Task<int> EditBooking(Booking booking)
        {
            Booking bookingToEdit = await _context.Bookings.Where(b => b.Id == booking.Id).FirstOrDefaultAsync().ConfigureAwait(false);
            if (bookingToEdit != null)
                bookingToEdit = booking;

            return _context.SaveChanges();
        }

        public async Task<int> DeleteBooking(int id)
        {
            Booking bookingToDelete = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (bookingToDelete != null)
                _context.Bookings.Remove(bookingToDelete);

            return _context.SaveChanges();
        }

        public async Task<List<Booking>> GetBookings()
        {
            return await _context.Bookings.ToListAsync().ConfigureAwait(false);
        }
    }
}
