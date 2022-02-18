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
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger logger;

        public UserController(IUserService service, ILogger log)
        {
            userService = service;
            logger = log;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("/GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<User> result = await userService.GetUsersAsync().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("/GetUsers/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            User result = await userService.GetUserAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouvé", id);
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("/AddUsers")]
        public async Task<IActionResult> AddUser([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                int result = await userService.AddUserAsync(user).ConfigureAwait(false);
                if (result > 0)
                    return Ok(result);
            }

            return Problem("Invalid properties", "EditUser", (int)HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("/EditUsers")]
        public async Task<IActionResult> EditUser([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                int result = await userService.EditUserAsync(user).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error($"Ressource non trouvée {user.Id}");
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return Problem("Invalid properties", "EditUser", (int)HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("DeleteUsers/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            int result = await userService.DeleteUserAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouvée", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}