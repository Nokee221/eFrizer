using eFrizer.Model;
using eFrizer.Services;

namespace eFrizer.Controllers
{
    public class HairSalonHairDresserController : BaseCRUDController<Model.HairSalonHairDresser, HairSalonHairDresserSearchRequest, Model.HairSalonHairDresserInsertRequest, object>
    {
        public HairSalonHairDresserController(IHairSalonHairDresserService service)
            : base(service)
        {

        }
    }
}
