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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        } 

        [HttpGet]
        [Route("/Get")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            User result = await userService.GetUserAsync(id).ConfigureAwait(false);

            return Ok(result);
        }

        [HttpGet]
        [Route("/All")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> result = await userService.GetUsersAsync().ConfigureAwait(false);

            return Ok(result.ToList());
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> AddUser([FromForm] User user)
        {
            int result = await userService.AddUserAsync(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> EditUser([FromForm] User user)
        {
            int result = await userService.EditUserAsync(user).ConfigureAwait(false);

            return Ok(result);

        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int result = await userService.DeleteUserAsync(id);

            return Ok(result);
        }
    }
}