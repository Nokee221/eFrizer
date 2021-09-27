using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class PictureController : BaseCRUDController<Model.Picture, object, PictureInsertRequest, PictureUpdateRequest>
    {
        public PictureController(ICRUDService<Model.Picture, object, PictureInsertRequest, PictureUpdateRequest> service)
            : base(service)
        {
            
        }

        [HttpPost]
        public override async Task<Model.Picture> Insert([FromForm] PictureInsertRequest request)
        {
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
