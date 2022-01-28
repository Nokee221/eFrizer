using eFrizer.Model;
using eFrizer.Services;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class PictureController : BaseCRUDController<Model.Picture, object, PictureInsertRequest, PictureUpdateRequest>
    {
        private new IPictureService _service;

        public PictureController(IPictureService service)
            : base(service)
        {
            _service = service;
        }

        [HttpGet("/PictureStream")]
        public async Task<FileContentResult> GetPictureStream([FromQuery] int imageId)
        {
            var imageBytes = await _service.GetPictureStream(imageId);
            return File(imageBytes, "image/jpeg");
        }

        [HttpGet("/PictureIds")]
        public async Task<Gallery> GetHairSalonPictures([FromQuery] int hairSalonId)
        {
            var gallery = await _service.GetPictureIds(hairSalonId);
            return gallery;
        }


        [HttpPost]
        public override async Task<Model.Picture> Insert([FromForm] PictureInsertRequest request)
        {
            var form = Request.Form;
            request.ImageFile = form.Files[0];
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public override async Task<Model.Picture> Update(int id,[FromForm] PictureUpdateRequest request)
        {
            return await _crudService.Update(id, request);
        }


        //TODO: the controller returns only the model on get requests, maybe it should return the bytes for the image?
    }
}
