using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company
{
    public class CompanyMainWindowViewModel : BaseMainWindowViewModel
    {
        public override string Role => "Công ty";

        protected override void SetNavigationItems()
        {
            NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Chi nhánh", Icon = PackIconKind.HomeCity, NavigationItemSelectedCallback = _ => new AgencyContentViewModel(), IsSelected = true },
                new FirstLevelNavigationItem() { Label = "Nhân viên", Icon = PackIconKind.AccountGroup, NavigationItemSelectedCallback = _ => new StaffContentViewModel()},
                new FirstLevelNavigationItem() { Label = "Loại nhà", Icon = PackIconKind.ShieldHome, NavigationItemSelectedCallback = _ => new HouseCategoryContentViewModel() },
                new FirstLevelNavigationItem() { Label = "Nhà", Icon = PackIconKind.HomeModern, NavigationItemSelectedCallback = _ => new HouseContentViewModel() },
                new FirstLevelNavigationItem() { Label = "Khách hàng", Icon = PackIconKind.AccountSupervisor, NavigationItemSelectedCallback = _ => new CustomerContentViewModel() }
            };
            SelectedNavigationItem = NavigationItems[0];
        }
    }
}
