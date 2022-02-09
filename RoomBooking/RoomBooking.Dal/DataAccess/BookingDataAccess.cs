using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Dal.Interfaces;
using System.Data.Entity;
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
        
        public async Task<Booking> GetBooking(int id)
        {
            return  await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
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
    }
}
