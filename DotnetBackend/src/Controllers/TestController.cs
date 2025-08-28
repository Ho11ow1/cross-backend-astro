using Microsoft.AspNetCore.Mvc;

using DotnetBackend.Services;

namespace DotnetBackend.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        private readonly TestService _testService;

        public TestController(TestService testService)
        {
            _testService = testService;
        }

        [HttpGet("Greet/{name}")]
        public IActionResult GetGreeting(string name)
        {
            var message = _testService.GetGreeting(name);
            return Ok(new 
            { 
                Message = message
            });
        }
    }
}