using eFrizer.Services;

namespace eFrizer.Controllers
{
    public class HairSalonServiceLoyaltyBonusController : BaseCRUDController<Model.HairSalonServiceLoyaltyBonus, object, Model.HairSalonServiceLoyaltyBonusInsertRequest, object>
    {
        public HairSalonServiceLoyaltyBonusController(IHairSalonServiceLoyaltyBonusService service) : base(service)
        {
                
        }
    }
}
