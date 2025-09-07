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
        private readonly DatabaseService _databaseService;

        public TestController(TestService service, DatabaseService databaseService)
        {
            _service = service;
            _databaseService = databaseService;
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
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _databaseService.GetUsersAsync();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _databaseService.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("users/{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            try
            {
                var result = await _databaseService.DeleteUserByIdAsync(id);
                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}