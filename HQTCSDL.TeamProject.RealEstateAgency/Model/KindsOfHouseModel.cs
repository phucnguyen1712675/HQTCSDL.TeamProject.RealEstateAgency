using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class KindsOfHouseModel : INotifyPropertyChanged
    {
        public KindsOfHouseModel(string name)
        {
            KindsOfHouseID = KindsOfHouseViewModel.NextID++;
            Name = name;
        }
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int KindsOfHouseID { get; set; }
        public string Name { get; set; }
    }
}
