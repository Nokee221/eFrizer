using AutoMapper;
using eFrizer.Database;
using eFrizer.Filters;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class PictureService : BaseCRUDService<Model.Picture, Database.Picture, object, PictureInsertRequest, PictureUpdateRequest>, IPictureService
    {
        private IWebHostEnvironment _hostEnvironment;
        private eFrizerContext _context;

        public PictureService(eFrizerContext context, IMapper mapper, IWebHostEnvironment hostEnvironment)
            : base(context, mapper)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<Byte[]> GetPictureStream(int imageId)
        {
            Byte[] imageBytes;
            try
            {
                string imageName = Path.GetFileName(Context.Pictures.Find(imageId).Path);
                string imagePath = "\\Images\\" + imageName;
                var path = _hostEnvironment.ContentRootPath + imagePath;
                imageBytes = await File.ReadAllBytesAsync(path);

                return imageBytes;
            }
            catch (Exception ex)
            {
                throw new UserException("Greska kod prikazivanja slika" + ex.Message);
            }
        }

        public async Task<Gallery> GetPictureIds(int hairSalonId)
        {
            var gallery = new Gallery();

            gallery.Rows = await Context.HairSalonPictures
                .Where(x => x.HairSalonId == hairSalonId)
                .Select(x => new Gallery.Row { pictureId = x.PictureId })
                .ToListAsync();
            gallery.pictureIds = new int[gallery.Rows.Count()];
            for (int i = 0; i < gallery.Rows.Count(); i++)
            {
                gallery.pictureIds[i] = gallery.Rows.ElementAt(i).pictureId;
            }
            return gallery;
        }
        public async override Task<Model.Picture> Insert(PictureInsertRequest request)
        {
            
            var imagePath = await UploadFile(request.ImageFile);

            var entry = _context.Pictures.Add(new Database.Picture()
            {
                Path = imagePath
            });

            _context.SaveChanges();

            var pictureId = _context.Pictures.OrderByDescending(x => x.PictureId).First().PictureId;
            var hairSalonPicture = _context.HairSalonPictures.Add(new Database.HairSalonPicture()
            {
                HairSalonId = request.HairSalonId,
                PictureId = pictureId
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
            string path = Path.Combine(_hostEnvironment.ContentRootPath + "/Images/" + imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
}
