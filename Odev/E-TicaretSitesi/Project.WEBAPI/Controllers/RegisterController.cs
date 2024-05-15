using Microsoft.AspNetCore.Mvc;
using Project.Bll.ManagerServices.Abstracts;
using Project.Entities.Models;
using Project.WEBAPI.Models.AppUser.RequestModels;

namespace Project.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
         IAppUserManager _appUserManager;

        public RegisterController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel item)
        {
            AppUser appUser = new()
            {
                UserName = item.UserName,
                Email = item.Email,
                PasswordHash = item.Password,

            };

            bool result = await _appUserManager.CreateUserAsync(appUser);

            if (result)
            {
                return Ok("Kullanıcı ekleme başarılı");
            }

            return BadRequest("Kullanıcı ekleme kısmında bir sorunla karşılaşıldı");

        }
    }
}
