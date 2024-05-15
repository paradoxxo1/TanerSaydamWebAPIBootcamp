using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class HelloWorldController : ControllerBase
{
    [HttpGet]
    public IActionResult Test(int age, string name)
    {
        return Ok("API is working...");
    }

    [HttpGet]
    public IActionResult Test2(int count) 
    {
        return Ok();
    }
}
