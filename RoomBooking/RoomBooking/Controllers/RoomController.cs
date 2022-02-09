using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;

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
        public async Task<Room> Get(int id)
        {
            return await roomService.GetRoom(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<int> AddRoom([FromForm] Room room)
        {
            return await roomService.AddRoom(room).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<int> EditRoom([FromForm] Room room)
        {
            return await roomService.EditRoom(room).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<int> DeleteRoom(int id)
        {
            return await roomService.DeleteRoom(id).ConfigureAwait(false);
        }
    }
}