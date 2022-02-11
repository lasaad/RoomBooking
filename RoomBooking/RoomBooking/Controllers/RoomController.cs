using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Api.Services;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
        public async Task<IActionResult> Get(int id)
        {
            Room result = await roomService.GetRoom(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        public async Task<IActionResult> AddRoom([FromForm] Room room)
        {
            int result = await roomService.AddRoom(room).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        public async Task<IActionResult> EditRoom([FromForm] Room room)
        {
            int result = await roomService.EditRoom(room).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetRoomsResponse))]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            int result = await roomService.DeleteRoom(id).ConfigureAwait(false);

            return Ok(result);
        }
    }
}