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
        [Route("/Bookings")]
        public async Task<IActionResult> GetBookings()
        {
            IEnumerable<Booking> result = await bookingService.GetBookingsAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [Route("/Bookings/{id}")]
        public async Task<IActionResult> GetBooking([FromQuery] int id)
        {
            Booking result = await bookingService.GetBookingAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouvé {id}", id);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Bookings")]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            BookingResponse result = await bookingService.AddBookingAsync(booking).ConfigureAwait(false);
            if (ModelState.IsValid)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Bookings")]
        public async Task<IActionResult> EditBooking([FromBody] Booking booking)
        {
            if (ModelState.IsValid)
            {
                int result = await bookingService.EditBookingAsync(booking).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error("Ressource non trouvée {Id}", booking.Id);
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetBookingsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [Route("/Bookings/{id}")]
        public async Task<IActionResult> DeleteBooking([FromQuery] int id)
        {
            int result = await bookingService.DeleteBookingAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouvée {id}", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
