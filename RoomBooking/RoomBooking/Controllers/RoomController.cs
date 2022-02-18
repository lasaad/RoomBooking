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
        [Route("/Rooms")]
        public async Task<IActionResult> GetRooms()
        {
            IEnumerable<Room> result = await roomService.GetRoomsAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [Route("/Rooms/{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            Room result = await roomService.GetRoomAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouvé {id}", id);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Rooms")]
        public async Task<IActionResult> AddRoom([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                int result = await roomService.AddRoomAsync(room).ConfigureAwait(false);
                if (result > 0)
                    return Ok(result);
                else
                {
                    logger.Error("Erreur lors de l'ajout de la ressouce {id}", room.Id);
                    BadRequest(ModelState);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Rooms")]
        public async Task<IActionResult> EditRoom([FromForm] Room room)
        {
            if (ModelState.IsValid)
            {
                int result = await roomService.EditRoomAsync(room).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error("Ressource non trouvée {Id}", room.Id);
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [Route("/Rooms/{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            int result = await roomService.DeleteRoomAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouvée {id}", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}