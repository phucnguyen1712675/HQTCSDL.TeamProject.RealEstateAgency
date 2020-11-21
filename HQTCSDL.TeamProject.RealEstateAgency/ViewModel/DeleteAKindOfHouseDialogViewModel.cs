using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class DeleteAKindOfHouseDialogViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public ObservableCollection<string> KindOfHouseList { get; set; }

        public DeleteAKindOfHouseDialogViewModel()
        {
            var viewModel = new KindsOfHouseViewModel();
            this.KindOfHouseList = new ObservableCollection<string>(viewModel.KindsOfHousesList.Select(c => c.Name).ToList());
        }
    }
}
