using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class PictureController : ControllerBase
    {
        private IWebHostEnvironment hostingEnvironment;

        public PictureController(IWebHostEnvironment environment)
        {
            hostingEnvironment = environment;
        }

        [HttpPost("UploadFile")]
        public async Task<string> UploadFile(IFormFile file)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
            string path = Path.Combine(hostingEnvironment.ContentRootPath, "Images/" + imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return imageName;
        }
    }
}
