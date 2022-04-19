using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValidateVersion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VersionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public VersionsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_configuration.GetValue<string>("version"));
        }

        [HttpGet("{version}")]
        public IActionResult Get(string version)
        {
            return Ok(_configuration.GetValue<string>("version") == version);
        }
    }
}
