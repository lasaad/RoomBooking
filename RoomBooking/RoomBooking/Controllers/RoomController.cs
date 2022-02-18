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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly ILogger logger;

        public RoomController(IRoomService service, ILogger log)
        {
            roomService = service;
            logger = log;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/GetRooms")]
        public async Task<IActionResult> GetRooms()
        {
            IEnumerable<Room> result = await roomService.GetRoomsAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/GetRooms/{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            Room result = await roomService.GetRoomAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouvé", id);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/AddRooms")]
        public async Task<IActionResult> AddRoom([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                int result = await roomService.AddRoomAsync(room).ConfigureAwait(false);
                if (result > 0)
                    return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/EditRooms")]
        public async Task<IActionResult> EditRoom([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                int result = await roomService.EditRoomAsync(room).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error($"Ressource non trouvée {room.Id}");
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return Problem("Invalid properties", "EditRoom", (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("DeleteRooms/{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            int result = await roomService.DeleteRoomAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouvée", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}