using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PostAPIController : ControllerBase
{
    //POST
    [HttpPost]
    public IActionResult Create(UserDto request)
    {
        return NoContent();
    }


    [HttpPut]
    public IActionResult Update()
    {
        return NoContent();
    }


    [HttpDelete]
    public IActionResult Delete()
    {
        return NoContent();
    }



}

public sealed record CreatedDto(
    UserDto userDto,
    CreatedDto createdDto);

public sealed record UserDto (
    int Age,
    string Name,
    string Email
    );
public sealed record CategoryDto(
    string name);
