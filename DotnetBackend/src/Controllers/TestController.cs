using Microsoft.AspNetCore.Mvc;

using DotnetBackend.Services;

namespace DotnetBackend.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestController : ControllerBase
    {
        private readonly TestService _service;

        public TestController(TestService service)
        {
            _service = service;
        }

        [HttpGet("greet/{name}")]
        public IActionResult GetGreeting(string name)
        {
            var message = _service.GetGreeting(name);
            return Ok(new 
            { 
                Message = message
            });
        }
    }
}