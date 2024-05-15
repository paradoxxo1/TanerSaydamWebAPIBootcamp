using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Abstractions
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class APIController : ControllerBase
    {
    }
}
