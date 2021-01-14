using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.ChiNhanhViewModel
{
    class ChiNhanhMainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NHA> Houses { get; set; }
        public ObservableCollection<CHUNHA> HouseOwners { get; set; }

        private static ChiNhanhMainViewModel instance;
        public static ChiNhanhMainViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ChiNhanhMainViewModel();
                }
                return instance;
            }
        }

        private ChiNhanhMainViewModel() {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Houses = new ObservableCollection<NHA>( db.NHAs.ToList());
                HouseOwners = new ObservableCollection<CHUNHA>(db.CHUNHAs.ToList());
            }
        }
    }
}
