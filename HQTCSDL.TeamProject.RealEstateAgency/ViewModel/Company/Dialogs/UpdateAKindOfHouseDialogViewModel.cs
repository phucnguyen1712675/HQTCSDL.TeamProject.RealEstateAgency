using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs
{
    public class UpdateAKindOfHouseDialogViewModel : BaseViewModel
    {
        public ObservableCollection<HouseCategory> HouseCateCollection { get; set; }

        public UpdateAKindOfHouseDialogViewModel()
        {
            this.HouseCateCollection = (new HouseCategoriesList()).GetHouseCategoriesList();
        }
    }
}
