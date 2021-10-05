using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class PictureService : BaseCRUDService<Model.Picture, Database.Picture, object, PictureInsertRequest, PictureUpdateRequest>, ICRUDService<Model.Picture, object, PictureInsertRequest, PictureUpdateRequest>
    {
        private IWebHostEnvironment _hostEnvironment;
        private eFrizerContext _context;

        public PictureService(eFrizerContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async override Task<Model.Picture> Insert(PictureInsertRequest request)
        {

            var imagePath = await UploadFile(request.ImageFile);

            var entry = _context.Pictures.Add(new Database.Picture()
            {
                Path = imagePath
            });

            _context.SaveChanges();

            return _mapper.Map<Model.Picture>(entry.Entity);
        }

        public async override Task<Model.Picture> Update(int id, PictureUpdateRequest request)
        {
            var entry = _context.Pictures.Where(x => x.PictureId == id).First();

            var oldPath = entry.Path;
            
            var newPath = await UploadFile(request.ImageFile);

            File.Delete(oldPath);
            
            entry.Path = newPath;

            _context.SaveChanges();

            return _mapper.Map<Model.Picture>(entry);

        }

        
        public async Task<string> UploadFile(IFormFile file)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
            string path = Path.Combine(_hostEnvironment.ContentRootPath + "Images/" + imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
}
