using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company
{
    public class CompanyMainWindowViewModel : BaseMainWindowViewModel
    {
        public override string Role => "Role: Công ty";

        protected override void SetNavigationItems()
        {
            NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Chi nhánh", Icon = PackIconKind.HomeCity, NavigationItemSelectedCallback = item => new AgencyContentViewModel(), IsSelected = true },
                new FirstLevelNavigationItem() { Label = "Nhân viên", Icon = PackIconKind.AccountGroup, NavigationItemSelectedCallback = item => new StaffContentViewModel()},
                new FirstLevelNavigationItem() { Label = "Loại nhà", Icon = PackIconKind.ShieldHome, NavigationItemSelectedCallback = item => new HouseCategoryContentViewModel() }
            };
            SelectedNavigationItem = NavigationItems[0];
        }
    }
}
