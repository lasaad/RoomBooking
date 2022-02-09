using RoomBooking.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomBooking.Dal.Interfaces;


namespace RoomBooking.Dal.DataAccess
{
    public class BookingDataAccess : IBookingDataAccess
    {
        private readonly KataHotelContext _context;

        public BookingDataAccess(KataHotelContext context)
        {
            _context = context; 
        }
        
        public Booking GetBooking(int id)
        {
            return _context.Bookings.Where(b => b.Id == id).FirstOrDefault();
        }

        public int AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            return _context.SaveChanges();
        }

        public int EditBooking(Booking booking)
        {
            Booking bookingToEdit = _context.Bookings.Where(b => b.Id == booking.Id).FirstOrDefault();
            if (bookingToEdit != null)
                bookingToEdit = booking;

            return _context.SaveChanges();
        }

        public int DeleteBooking(int id)
        {
            Booking bookingToDelete = _context.Bookings.Where(b => b.Id == id).FirstOrDefault();

            if (bookingToDelete != null)
                _context.Bookings.Remove(bookingToDelete);

            return _context.SaveChanges();
        }
    }
}
