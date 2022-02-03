using eFrizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class HairSalonServicePictureController : BaseCRUDController<Model.HairSalonServicePicture, Model.HairSalonServicePictureSearchRequest, Model.HairSalonServicePictureInsertRequest, Model.HairSalonServicePictureUpdateRequest>
    {
        public HairSalonServicePictureController(IHairSalonServicePictureService service) : base(service)
        {

        }
    }
}
