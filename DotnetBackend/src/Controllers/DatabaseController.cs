using Microsoft.AspNetCore.Mvc;

using DotnetBackend.Services;

namespace DotnetBackend.Controllers
{
    [ApiController]
    [Route("api")]
    public class DatabaseController : ControllerBase
    {
        private readonly DatabaseService _service;

        public DatabaseController(DatabaseService service)
        {
            _service = service;
        }

        
    }
}