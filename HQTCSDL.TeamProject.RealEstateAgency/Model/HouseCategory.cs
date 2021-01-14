using PropertyChanged;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    [AddINotifyPropertyChangedInterface]
    public class HouseCategory
    {
        public int KindsOfHouseID { get; set; }
        public string Name { get; set; }
    }
}
