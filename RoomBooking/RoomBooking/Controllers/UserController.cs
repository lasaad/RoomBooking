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
        public async Task<User> Get(int id)
        {
            return await userService.GetUser(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<int> AddUser([FromForm] User user)
        {
            return await userService.AddUser(user).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<int> EditUser([FromForm] User user)
        {
            return await userService.EditUser(user).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<int> DeleteUser(int id)
        {
            return await userService.DeleteUser(id).ConfigureAwait(false);
        }
    }
}