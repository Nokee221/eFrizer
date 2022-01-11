

namespace eFrizer.Model
{
    public class HairSalonServiceLoyaltyBonus
    {
        public int Id { get; set; }
        public int HairSalonServiceId { get; set; }
        public int Discount { get; set; }
        public int ActivatesOn { get; set; }
        public int ExpiresIn { get; set; }
        public virtual HairSalonService Service { get; set; }

        public string ServiceName => Service?.ServiceName;

        //public int HairSalonId => Service.HairSalonId;
    }
}
