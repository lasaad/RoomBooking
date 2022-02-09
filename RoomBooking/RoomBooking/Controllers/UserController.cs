using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;

namespace RoomRoom.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            User result = await userService.GetUser(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromForm] User user)
        {
            int result = await userService.AddUser(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromForm] User user)
        {
            int result = await userService.EditUser(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int result = await userService.DeleteUser(id);

            return Ok(result);
        }
    }
}