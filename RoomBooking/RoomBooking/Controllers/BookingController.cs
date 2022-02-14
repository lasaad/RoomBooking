using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("/Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Booking result = await bookingService.GetBookingAsync(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> AddBooking([FromForm] Booking booking)
        {
            int result = await bookingService.AddBookingAsync(booking).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> EditBooking([FromForm] Booking booking)
        {
            int result = await bookingService.EditBookingAsync(booking).ConfigureAwait(false);
            
            return Ok(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            int result = await bookingService.DeleteBookingAsync(id).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
