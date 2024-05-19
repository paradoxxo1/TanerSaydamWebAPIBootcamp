using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Versioning.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("GetTodo")]
        [ApiVersion(1.0, Deprecated = true)]
        public IActionResult GetTodo()
        {
            return Ok(new { Messsage = "V1 Todo..." });
        }

        [HttpGet("GetTodo")]
        [ApiVersion(2)]
        public IActionResult GetTodoV2()
        {
            return Ok(new { Messsage = "V2 Todo..." });
        }
    }
}
