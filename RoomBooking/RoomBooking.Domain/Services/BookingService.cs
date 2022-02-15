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

        public async Task<List<(int, int)>> GetAvailableSlot(DateTime day, int room)
        {
            List<(int, int)> result = new List<(int,int)>();
            var bookings = (await _bookingRepository.GetBookingsByRoomAndDayAsync(day, room)).OrderBy(b => b.StartSlot).ToList();
            int?[] slots = new int?[24]; 
            (int, int) availableSlot = (-1, -1);

            foreach(var slot in bookings)
            {
                for (int i = slot.StartSlot; i < slot.EndSlot; i++)
                {
                    slots[i] = i;
                }          
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if(slots[i] != null)
                {
                    if (availableSlot.Item1 == -1)
                        availableSlot = (slots[i].Value, -1);
                    else if(availableSlot.Item2 == -1)
                    {
                        availableSlot = (availableSlot.Item1, slots[i].Value);
                        result.Add(availableSlot);
                        availableSlot = (-1, -1);
                    }
                }        
            }

            return result;
        }
    }
}
