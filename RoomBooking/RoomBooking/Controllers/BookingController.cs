
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Services;
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
        public async Task<IActionResult> Get(int id)
        {
            Booking result = await bookingService.GetBooking(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([FromForm] Booking booking)
        {
            int result = await bookingService.AddBooking(booking).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> EditBooking([FromForm] Booking booking)
        {
            int result = await bookingService.EditBooking(booking).ConfigureAwait(false);
            
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            int result = await bookingService.DeleteBooking(id).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
