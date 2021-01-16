using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.StaffView.ContentControls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.StaffView
{
    public class StaffMainWindowViewModel : BaseMainWindowViewModel
    {
        public override string Role => "Nhân viên";

        protected override void SetNavigationItems()
        {
            NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Nhân viên", Icon = PackIconKind.HomeCity, NavigationItemSelectedCallback = _ => new HomeScreenViewModel(), IsSelected = true }
            };
            SelectedNavigationItem = NavigationItems[0];
        }
    }
}
