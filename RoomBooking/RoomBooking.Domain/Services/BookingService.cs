using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<BookingResponse> AddBookingAsync(Booking booking)
        {
            BookingResponse result = new BookingResponse();
            var bookings = (await _bookingRepository.GetBookingsByRoomAndDayAsync(booking.Date, booking.RoomId))
                .OrderBy(b => b.StartSlot)
                .ToList();

            List<Booking> bookedHours = new List<Booking>();

            foreach(var b in bookings)
            {
                if (b.EndSlot != b.StartSlot + 1 )
                {
                    for (int i = b.StartSlot; i < b.EndSlot; i++)
                    {
                        //Impossible de modifier une liste énuméré du coup on stock dans une nouelle liste
                        bookedHours.Add(new Booking() { StartSlot = i});
                    }
                }
            }

            bookings.AddRange(bookedHours);

            if (bookings.Select(s => s.StartSlot).Contains(booking.StartSlot))
            {
                List<int> availableSlots = await GetAvailableSlot(booking.Date, booking.RoomId, bookings);
                return new BookingResponse() { AvailableHours = availableSlots, IsAvailable = false };
            }
            else
            {
                await _bookingRepository.AddBookingsAsync(booking);
                return new BookingResponse() { AvailableHours = null, IsAvailable = true };
            }
        }

        public async Task<int> DeleteBookingAsync(int id)
        {
            return await _bookingRepository.DeleteBookingAsync(id);
        }

        public async Task<int> EditBookingAsync(Booking booking)
        {
            return await _bookingRepository.EditBookingsAsync(booking);
        }

        public async Task<Booking> GetBookingAsync(int id)
        {
            return await _bookingRepository.GetBookingAsync(id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _bookingRepository.GetBookingsAsync();
        }

        public async Task<List<int>> GetAvailableSlot(DateTime day, int room, List<Booking> furtherElement = null)
        {
            List<(int, int)> result = new List<(int, int)>();
            var bookings = (await _bookingRepository.GetBookingsByRoomAndDayAsync(day, room)).Select(b => b.StartSlot)
                .OrderBy(b => b)
                .ToList();
            if(furtherElement != null)
            {
                bookings.AddRange(furtherElement.Select(f => f.StartSlot));
            }

            List<int> hours = new List<int> {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23 };

            return hours.Where(b => !bookings.Contains(b)).ToList();

        }
    }
}