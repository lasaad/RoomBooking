using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;

namespace RoomBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService service)
        {
            bookingService = service;
        }

        public void Get(int id)
        {
            bookingService.GetBooking(id);
        }

        public int AddBooking([FromForm] Booking booking)
        {
            return bookingService.AddBooking(booking);
        }

        public int EditBooking([FromForm] Booking booking)
        {
            return bookingService.EditBooking(booking);
        }

        public int DeleteBooking(int id)
        {
            return bookingService.DeleteBooking(id);
        }
    }
}