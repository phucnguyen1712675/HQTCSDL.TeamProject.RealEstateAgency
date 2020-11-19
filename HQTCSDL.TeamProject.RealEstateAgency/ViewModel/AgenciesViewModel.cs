using HQTCSDL.TeamProject.RealEstateAgency.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class AgenciesViewModel
    {
        public static int NextId = 1;
        public ObservableCollection<AgenciesModel> AgenciesList { get; set; } =
            new ObservableCollection<AgenciesModel>()
        {
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS")
        };
    }
}
