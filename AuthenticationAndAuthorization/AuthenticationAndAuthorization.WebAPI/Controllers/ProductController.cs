using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AuthenticationAndAuthorization.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]

    public sealed class ProductController : ControllerBase
    {
        [HttpGet]
        //[MyAuthorize]
        public ActionResult GetAll()
        {
            var httpContex = HttpContext;
            var userId = httpContex.User.Claims.First(p => p.Type == ClaimTypes.NameIdentifier).Value;
            return Ok();
        }
    }
}
