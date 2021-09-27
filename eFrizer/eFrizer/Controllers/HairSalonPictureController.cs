using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonPictureController : BaseReadController<Model.HairSalonPicture, object>
    {
        private new IHairSalonPictureService _service;

        public HairSalonPictureController(IHairSalonPictureService service)
            : base(service)
        {
            _service = service;
        }

        //TODO: Is this the best way to disable the base put service from BaseCRUD? I have to rewrite the Post method exactly the same.
        //TODO: Maybe a better idea would be to make a separate interfaces for each base http action. BaseCreate, BaseRead, BaseUpdate, BaseDelete?

        [HttpPut("{id_1},{id_2}")]
        public async Task<HairSalonPicture> Update(int id_1, int id_2, [FromBody] HairSalonPictureUpdateRequest request)
        {
            return await _service.Update(id_1, id_2, request);
        }

        [HttpPost]
        public async Task<HairSalonPicture> Insert([FromBody] HairSalonPictureInsertRequest request)
        {
            return await _service.Insert(request);
        }
        

    }
}
