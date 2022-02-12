
using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;
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
        public async Task<IActionResult> Get(int id)
        {
            BookingEntity result = await bookingService.GetBooking(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> AddBooking([FromForm] BookingEntity booking)
        {
            int result = await bookingService.AddBooking(booking).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> EditBooking([FromForm] BookingEntity booking)
        {
            int result = await bookingService.EditBooking(booking).ConfigureAwait(false);
            
            return Ok(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            int result = await bookingService.DeleteBooking(id).ConfigureAwait(false);

            return Ok(result);
        }
    }
}
