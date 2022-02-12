using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RoomBooking.Api.Controllers
{
    [Route("Values")]
    public class ValueController : Controller
    {
        private readonly IValueService _valueService;

        public ValueController(IValueService valueService) =>
            _valueService = valueService;

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetValuesResponse))]
        public async Task<IActionResult> GetValuesAsync()
        {
            var tests = await _valueService.GetValuesAsync();
            
            return Ok(tests.Select(t => new ValueDto
            {
                Id = t.Id,
                Name = t.Name
            }));
        }
    }
}
