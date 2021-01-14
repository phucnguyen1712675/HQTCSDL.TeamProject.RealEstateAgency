using PropertyChanged;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Agency
    {
        public int AgencyId { get; set; }
        public string Fax { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
