using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.House
{
    public class HouseDetailViewModel : BaseViewModel
    {
        public NHA SelectedHouse { get; set; }
        public CHITIETNHATHUE SelectedRentalHouseDetail { get; set; }
        public ObservableCollection<CHINHANH> AgenciesCollection { get; set; }
        public ObservableCollection<CHUNHA> HouseOwnersCollection { get; set; }
        public ObservableCollection<NHANVIEN> StaffsCollection { get; set; }
        public ObservableCollection<LOAINHA> HouseCatesCollection { get; set; }
    }
}
