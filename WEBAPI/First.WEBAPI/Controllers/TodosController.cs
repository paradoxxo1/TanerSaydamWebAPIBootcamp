using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TodosController : ControllerBase
{
    [HttpPost]
    public IActionResult Create(UserDto request)
    {
        //var context = HttpContext;
        return NoContent();
    }


    [HttpGet]
    public IActionResult GetAll()
    {
        return NoContent();
    }

    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}
