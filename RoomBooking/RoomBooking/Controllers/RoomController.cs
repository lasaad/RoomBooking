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
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService service)
        {
            roomService = service;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            RoomEntity result = await roomService.GetRoom(id).ConfigureAwait(false);

            if (result == null)
                return NotFound(result);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/AddRoom")]
        public async Task<IActionResult> AddRoom([FromForm] RoomEntity room)
        {
            int result = await roomService.AddRoom(room).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("/EditRoom")]
        public async Task<IActionResult> EditRoom([FromForm] RoomEntity room)
        {
            int result = await roomService.EditRoom(room).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        [Route("DeleteRoom/{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            int result = await roomService.DeleteRoom(id).ConfigureAwait(false);

            if (result == 0)
                return Problem();

            return Ok(result);
        }
    }
}