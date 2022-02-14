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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService service)
        {
            roomService = service;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/GetRoom/{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            Room result = await roomService.GetRoomAsync(id).ConfigureAwait(false);

            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/AddRoom")]
        public async Task<IActionResult> AddRoom([FromForm] Room room)
        {
            int result = await roomService.AddRoomAsync(room).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/EditRoom")]
        public async Task<IActionResult> EditRoom([FromForm] Room room)
        {
            int result = await roomService.EditRoomAsync(room).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("DeleteRoom/{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            int result = await roomService.DeleteRoomAsync(id).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }
    }
}