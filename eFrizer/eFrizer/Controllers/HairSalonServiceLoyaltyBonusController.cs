using eFrizer.Services;

namespace eFrizer.Controllers
{
    public class HairSalonServiceLoyaltyBonusController : BaseCRUDController<Model.HairSalonServiceLoyaltyBonus, Model.HairSalonServiceLoyaltyBonusSearchRequest, Model.HairSalonServiceLoyaltyBonusInsertRequest, object>
    {
        public HairSalonServiceLoyaltyBonusController(IHairSalonServiceLoyaltyBonusService service) : base(service)
        {
                
        }
    }
}
