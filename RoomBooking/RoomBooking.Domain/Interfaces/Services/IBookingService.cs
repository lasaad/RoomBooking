﻿using System.Collections.Generic;
using System.Threading.Tasks;
using RoomBooking.Domain.Models;

namespace RoomBooking.Domain.Interfaces.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingAsync(int id);
        Task<int> EditBookingAsync(Booking booking);
        Task<int> AddBookingAsync(Booking booking);
        Task<int> DeleteBookingAsync(int id);
    }
}