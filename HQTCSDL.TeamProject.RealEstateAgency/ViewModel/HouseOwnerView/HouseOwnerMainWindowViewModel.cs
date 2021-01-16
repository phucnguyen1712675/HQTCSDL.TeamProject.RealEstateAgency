using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView.ContentControls;
using MaterialDesignExtensions.Model;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView
{
    public class HouseOwnerMainWindowViewModel : BaseMainWindowViewModel
    {
        public override string Role => "Chủ nhà";

        protected override void SetNavigationItems()
        {
            NavigationItems = new List<INavigationItem>()
            {
                new FirstLevelNavigationItem() { Label = "Chủ nhà", Icon = PackIconKind.HomeCity, NavigationItemSelectedCallback = item =>  HomeScreenViewModel.Instance, IsSelected = true }
            };
            SelectedNavigationItem = NavigationItems[0];
        }
    }
}
