using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Api.HubConfig;
using RoomBooking.Dal.Models;
using RoomBooking.Domain.Interfaces.Services;
using RoomBooking.Domain.Models;
using Swashbuckle.AspNetCore.Annotations;
using ILogger = Serilog.ILogger;

namespace RoomBooking.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILogger logger;
        private readonly IHubContext<UserHub> hub;

        public UserController(IUserService service, ILogger log, IHubContext<UserHub> userHub)
        {
            userService = service;
            logger = log;
            hub = userHub;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [Route("/Users")]
        public async Task<IActionResult> GetUsers()
        {
            await hub.Clients.All.SendAsync("transferchartdata");


            IEnumerable<User> result = await userService.GetUsersAsync().ConfigureAwait(false);
            var r = new GetUsersResponse()
            {
                Users = result.Select(s => new UserDto { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName })
            };
            return Ok(r);
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Users/{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            User result = await userService.GetUserAsync(id).ConfigureAwait(false);

            if (result == null)
            {
                logger.Error("Ressouce non trouv� {id}", id);
                return BadRequest(ModelState);
            }

            return Ok(result);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Users")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                int result = await userService.AddUserAsync(user).ConfigureAwait(false);
                if (result > 0)
                    return Ok(result);
                else
                {
                    logger.Error("Erreur lors de l'ajout de la ressouce {id}", user.Id);
                    BadRequest(ModelState);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestObjectResult))]
        [Route("/Users")]
        public async Task<IActionResult> EditUser([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                int result = await userService.EditUserAsync(user).ConfigureAwait(false);
                if (result == 0)
                {
                    logger.Error("Ressource non trouv�e {id}", user.Id);
                    return NotFound(result);
                }
                return Ok(result);

            }
            else
                return BadRequest(ModelState);
        }

        [HttpDelete]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetUsersResponse))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Type = typeof(NotFoundObjectResult))]
        [Route("/Users/{id}")]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            int result = await userService.DeleteUserAsync(id).ConfigureAwait(false);

            if (result == 0)
            {
                logger.Error("Ressource non trouv�e {id}", id);
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}