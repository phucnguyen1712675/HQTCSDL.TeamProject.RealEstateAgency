using MaterialDesignExtensions.Model;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public abstract class BaseMainWindowViewModel : BaseViewModel
    {
        public static BaseMainWindowViewModel Instance;
        public string Title { get; }
        public string Identifier { get; }
        public bool IsNavigationDrawerOpen { get; set; }
        public List<INavigationItem> NavigationItems { get; set; }
        public INavigationItem SelectedNavigationItem { get; set; }
        public abstract string Role { get;}

        public BaseMainWindowViewModel()
        {
            Instance = this;
            Title = "Ứng dụng môi giới nhà đất";
            Identifier = "mainWindowDialogHost";
            IsNavigationDrawerOpen = false;
            SetNavigationItems();
        }

        protected abstract void SetNavigationItems();
    }
}
