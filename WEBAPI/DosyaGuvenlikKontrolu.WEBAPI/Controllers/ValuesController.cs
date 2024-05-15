using Microsoft.AspNetCore.Mvc;

namespace DosyaGuvenlikKontrolu.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        public IActionResult SaveFile([FromForm] IFormFile file)
        {
            //137, 80,78,71 => jpeg
            //255,216,255 => png
            //70, 90, 144 => exe

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                byte[] fileBytes = stream.ToArray();
            }
            return NoContent();
        }
    }
}



//public static class Extensions
//{
//    public static bool CheckFileForJpg(this IFormFile file)
//    {
//        using (var stream = new MemoryStream())
//        {
//            file.CopyTo(stream);
//            byte[] fileBytes = stream.ToArray();
//            string jpgValue = fileBytes[0].ToString() + fileBytes[1].ToString() + fileBytes[2].ToString();


//            if (jpgValue != "255216255")
//            {
//                return false;
//            }
//        }
//        return true;
//    }
//}