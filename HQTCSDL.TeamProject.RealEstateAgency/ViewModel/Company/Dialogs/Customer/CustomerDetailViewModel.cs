using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.Customer
{
    public class CustomerDetailViewModel : BaseViewModel
    {
        public KHACHHANG SelectedCustomer { get; set; }
        public ObservableCollection<CHINHANH> AgenciesCollection { get; set; }
    }
}
