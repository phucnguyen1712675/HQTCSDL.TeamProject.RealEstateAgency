using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class AgenciesModel : INotifyPropertyChanged
    {
        public AgenciesModel(string fax, string phoneNumber, string address)
        {
            AgencyId = AgenciesViewModel.NextId++;
            Fax = fax;
            PhoneNumber = phoneNumber;
            Address = address;
        }
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int AgencyId { get; set; }
        public string Fax { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
