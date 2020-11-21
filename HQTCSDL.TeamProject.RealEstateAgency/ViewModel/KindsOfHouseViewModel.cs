using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class KindsOfHouseViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public static int NextID = 1;

        public ObservableCollection<KindsOfHouseModel> KindsOfHousesList { get; set; } = new ObservableCollection<KindsOfHouseModel>()
        {
            new KindsOfHouseModel("Nhà 1 lầu"),
            new KindsOfHouseModel("Nhà 2 lầu"),
            new KindsOfHouseModel("Nhà 3 lầu"),
            new KindsOfHouseModel("Nhà chung cư"),
            new KindsOfHouseModel("Nhà trọ"),
            new KindsOfHouseModel("Nhà thổ cư")
        };
    }
}
