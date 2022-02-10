using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Api.Services.Interface;
using RoomBooking.Dal.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

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
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> Get(int id)
        {
            User result = await userService.GetUser(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("/All")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> Get()
        {
            List<User> result = await userService.GetUsers().ConfigureAwait(false);

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> AddUser([FromForm] User user)
        {
            int result = await userService.AddUser(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> EditUser([FromForm] User user)
        {
            int result = await userService.EditUser(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int result = await userService.DeleteUser(id);

            return Ok(result);
        }
    }
}