using Microsoft.AspNetCore.Mvc;

namespace MinimalAPI2.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
