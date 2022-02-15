using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Repositories;
using RoomBooking.Domain.Models;

namespace RoomBooking.Dal.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly KataHotelContext _context;
        private readonly MapperConfiguration _mapper;

        public BookingRepository(KataHotelContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookingEntity, Booking>());
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
            Booking bookingDTO = mapper.Map<Booking>(a);

            return bookingDTO;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            Mapper mapper = new(_mapper);
            var a = await _context.Bookings.ToListAsync().ConfigureAwait(false);
            List<Booking> bookingDTO = mapper.Map<List<Booking>>(a);

            return bookingDTO;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByRoomAndDayAsync(DateTime day, int roomId)
        {
            Mapper mapper = new(_mapper);
            var bookings = await _context.Bookings
                                    .Where(b => b.Date == day && b.RoomId == roomId)
                                    .ToListAsync()
                                    .ConfigureAwait(false);
            List<Booking> bookingDTO = mapper.Map<List<Booking>>(bookings);

            return bookingDTO;
        }

        public async Task<int> EditBookingsAsync(Booking booking)
        {
            Mapper mapper = new(_mapper);

            BookingEntity bookingDTO = mapper.Map<BookingEntity>(booking);
            BookingEntity? bookingToEdit = await _context.Bookings.Where(b => b.Id == bookingDTO.Id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (bookingToEdit != null)
                bookingToEdit = bookingDTO;

            return _context.SaveChanges();
        }

        public async Task<int> AddBookingsAsync(Booking booking)
        {
            Mapper mapper = new(_mapper);
            BookingEntity bookingEntity = mapper.Map<BookingEntity>(booking);
            await _context.Bookings.AddAsync(bookingEntity).ConfigureAwait(false);

            return _context.SaveChanges();
        }

        public async Task<int> DeleteBookingAsync(int id)
        {
            Mapper mapper = new(_mapper);
            BookingEntity? bookingToDelete = await _context.Bookings.Where(b => b.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);

            if (bookingToDelete != null)
                _context.Bookings.Remove(bookingToDelete);

            return _context.SaveChanges();
        }
    }
}
