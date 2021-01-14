using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs
{
    public class DeleteAKindOfHouseDialogViewModel : BaseViewModel
    {
        public ObservableCollection<HouseCategory> HouseCateCollection { get; set; }

        public DeleteAKindOfHouseDialogViewModel()
        {
            this.HouseCateCollection = (new HouseCategoriesList()).GetHouseCategoriesList();
        }
    }
}
