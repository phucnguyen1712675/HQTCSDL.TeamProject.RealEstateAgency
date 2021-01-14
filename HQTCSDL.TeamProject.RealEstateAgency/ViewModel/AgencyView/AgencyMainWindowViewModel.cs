using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView.ContentControls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView
{
    public class AgencyMainWindowViewModel : BaseMainWindowViewModel
    {
        public override string Role => "Role: Chi nhánh";

        protected override void SetNavigationItems()
        {
            NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Chi nhánh", Icon = PackIconKind.HomeCity, NavigationItemSelectedCallback = item => HomeScreenViewModel.Instance, IsSelected = true }
            };
            SelectedNavigationItem = NavigationItems[0];
        }
    }
}
