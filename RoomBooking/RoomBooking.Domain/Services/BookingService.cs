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

        public async Task<int> AddBookingAsync(Booking booking)
        {
            return await _bookingRepository.AddBookingsAsync(booking);
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

        public async Task<List<(int, int)>> GetAvailableSlot(DateTime day, int room)
        {
            List<(int, int)> result = new List<(int, int)>();
            var bookings = (await _bookingRepository.GetBookingsByRoomAndDayAsync(day, room)).OrderBy(b => b.StartSlot).ToList();
            int?[] slots = new int?[24];
            (int, int) availableSlot = (-1, -1);

            foreach (var slot in bookings)
            {
                for (int i = slot.StartSlot; i < slot.EndSlot + 1; i++)
                {
                    slots[i] = i;
                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (availableSlot == (-1, -1))
                {
                    if (slots[i] == null)
                    {
                        availableSlot = (i, -1);
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    if (slots[i] == null)
                    {
                        continue;
                    }
                    else
                    {
                        availableSlot = (availableSlot.Item1, i);
                        result.Add(availableSlot);
                        availableSlot = (-1, -1);
                        
                    }
                }
            }

            if(availableSlot != (-1,-1))
            {
                availableSlot = (availableSlot.Item1, slots.Length);
                result.Add(availableSlot);
            }

            return result;
        }
    }
}
