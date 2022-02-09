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
        public async Task<Booking> Get(int id)
        {
            return await bookingService.GetBooking(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<int> AddBooking([FromForm] Booking booking)
        {
            return await bookingService.AddBooking(booking).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<int> EditBooking([FromForm] Booking booking)
        {
            return await bookingService.EditBooking(booking).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<int> DeleteBooking(int id)
        {
            return await bookingService.DeleteBooking(id).ConfigureAwait(false);
        }
    }
}
