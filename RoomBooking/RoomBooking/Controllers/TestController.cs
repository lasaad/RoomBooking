using System.Net;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Api.Dtos;
using RoomBooking.Api.Dtos.Responses;
using RoomBooking.Domain.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace RoomBooking.Api.Controllers
{
    [Route("Tests")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService) =>
            _testService = testService;

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetTestsResponse))]
        public async Task<IActionResult> GetTestsAsync()
        {
            var tests = await _testService.GetTestsAsync();
            
            return Ok(tests.Select(t => new TestDto
            {
                Id = t.Id,
                Name = t.Name
            }));
        }
    }
}
