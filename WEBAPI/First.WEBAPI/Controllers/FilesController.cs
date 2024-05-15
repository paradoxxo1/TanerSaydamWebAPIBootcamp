using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace First.WEBAPI.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class FilesController : ControllerBase
{
    [HttpPost]
    public IActionResult Create([FromForm] List<IFormFile> files)
    {

        #region Byte array çevirme
        //foreach (var file in files)
        //{
        //    using (var memorySteam = new MemoryStream())
        //    {
        //        file.CopyTo(memorySteam);
        //        var fileBytes = memorySteam.ToArray();
        //        string fileStrinng = Convert.ToBase64String(fileBytes);
        //    }
        //}
        #endregion

        #region Dosya Kaydetme
        foreach (var file in files)
        {
            string fileFormat  =file.FileName.Substring(file.FileName.LastIndexOf("."));
            string fileName = Guid.NewGuid().ToString() + fileFormat;
            using (var stream = System.IO.File.Create("wwwroot/" + file.FileName))
            {
                file.CopyTo(stream);
            }
        }
        #endregion
        return Ok();
    }
}
