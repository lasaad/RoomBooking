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

        [HttpGet]
        public void Get(int id)
        {
            bookingService.GetBooking(id);
        }

        [HttpPost]
        public int AddBooking([FromForm] Booking booking)
        {
            return bookingService.AddBooking(booking);
        }

        [HttpPut]
        public int EditBooking([FromForm] Booking booking)
        {
            return bookingService.EditBooking(booking);
        }

        [HttpDelete]
        public int DeleteBooking(int id)
        {
            return bookingService.DeleteBooking(id);
        }
    }
}