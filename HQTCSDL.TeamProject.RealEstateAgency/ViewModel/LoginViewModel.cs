using CakeShopApp.Utils;
using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System.Windows;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsChecked { get; set; }
        public ICommand RunExitAppCommand => new AnotherCommandImplementation(ExecuteExitApp);

        private void ExecuteExitApp(object obj)
           => Application.Current.Shutdown();

        public bool ContainUser(string userName, string password)
            => UsersList.IsContainUser(userName, password);

        internal BaseMainWindowViewModel GetCorrespondingViewModel(string role)
            => UserMainWindowDictinary.GetInstance().GetCorrespondingMainWindowViewModel(role);

        internal string GetUserRole(string userName, string password)
            => UsersList.GetUserRole(userName, password);
    }
}
