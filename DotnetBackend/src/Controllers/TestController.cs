using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetUsersAsync();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}