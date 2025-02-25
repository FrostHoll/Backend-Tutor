using Microsoft.AspNetCore.Mvc;

namespace BackendTutor.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Hello([FromQuery] string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Ok($"Hello, {name}!");
            }
            return Ok("Hello world!");
        }
    }
}
