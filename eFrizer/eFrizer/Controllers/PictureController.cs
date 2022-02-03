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

        [HttpGet("/HairSalonPictureIds")]
        public async Task<Gallery> GetHairSalonPictures([FromQuery] int hairSalonId)
        {
            var gallery = await _service.GetHairSalonPictureIds(hairSalonId);
            return gallery;
        }

        [HttpGet("/HairSalonServicePictureIds")]
        public async Task<Gallery> GetHairSalonServicePictures([FromQuery] int hairSalonServiceId)
        {
            var gallery = await _service.GetHairSalonServicePictureIds(hairSalonServiceId);
            return gallery;
        }


        [HttpPost("/InsertHairSalonPicture")]
        public async Task<Model.Picture> InsertHairSalonPicture([FromForm] PictureInsertRequest request)
        {
            var form = Request.Form;
            request.ImageFile = form.Files[0];
            return await _service.InsertHairSalonPicture(request);
        }

        [HttpPost("/InsertHairSalonServicePicture")]
        public async Task<Model.Picture> InsertHairSalonServicePicture([FromForm] PictureInsertRequest request)
        {
            var form = Request.Form;
            request.ImageFile = form.Files[0];
            return await _service.InsertHairSalonServicePicture(request);
        }

        [HttpPut("{id}")]
        public override async Task<Model.Picture> Update(int id,[FromForm] PictureUpdateRequest request)
        {
            return await _crudService.Update(id, request);
        }

        //TODO: the controller returns only the model on get requests, maybe it should return the bytes for the image?
    }
}
