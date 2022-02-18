using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using ILogger = Serilog.ILogger;

namespace RoomBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;
        private readonly ILogger logger;

        public BookingController(IBookingService service, ILogger log)
        {
            bookingService = service;
            logger = log;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("/GetBookings")]
        public async Task<IActionResult> GetBookings()
        {
            IEnumerable<Booking> result = await bookingService.GetBookingsAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("/GetBookings/{id}")]
        public async Task<IActionResult> GetBooking(int id)
        {
            Booking result = await bookingService.GetBookingAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouvé", id);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("/AddBookings")]
        public async Task<IActionResult> AddBooking([FromForm] Booking booking)
        {
            if (ModelState.IsValid)
            {
                int result = await bookingService.AddBookingAsync(booking).ConfigureAwait(false);
                if (result > 0)
                    return Ok(result);
            }

            return Problem("Invalid properties", "EditBooking", (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("/EditBookings")]
        public async Task<IActionResult> EditBooking([FromForm] Booking booking)
        {
            if (ModelState.IsValid)
            {
                int result = await bookingService.EditBookingAsync(booking).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error($"Ressource non trouvée {booking.Id}");
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return Problem("Invalid properties", "EditBooking", (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [Route("DeleteBookings/{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            int result = await bookingService.DeleteBookingAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouvée", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
