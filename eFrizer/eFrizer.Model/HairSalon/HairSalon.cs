

namespace eFrizer.Model
{
    public partial class HairSalon
    {
        public int HairSalonId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }

}
