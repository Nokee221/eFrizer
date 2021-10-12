using eFrizer.Services;

namespace eFrizer.Controllers
{
    public class HairSalonHairDresserController : BaseCRUDController<Model.HairSalonHairDresser, object, Model.HairSalonHairDresserInsertRequest, object>
    {
        public HairSalonHairDresserController(IHairSalonHairDresserService service)
            : base(service)
        {

        }
    }
}
