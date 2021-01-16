using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.Staff
{
    public class StaffDetailViewModel : BaseViewModel
    {
        public NHANVIEN SelectedStaff { get; set; }
        public ObservableCollection<CHINHANH> AgenciesCollection { get; set; }
    }
}
