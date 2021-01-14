using CakeShopApp.Utils;
using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System.Windows;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private const string IsKeepMeLoggedInKey = "IsKeepMeLoggedIn";

        private UsersList UsersList;

        private UserMainWindowDictinary UserMainWindowDictinary;

        public bool IsChecked { get; set; }
        public ICommand RunExitAppCommand => new AnotherCommandImplementation(ExecuteExitApp);
        //public ICommand RunCheckedCommand => new AnotherCommandImplementation(ExecuteCheckedAction);

        public LoginViewModel()
        {
            GetUsersList();
            GetUserMainWindowDictinary();
        }

        private void GetUserMainWindowDictinary()
            => this.UserMainWindowDictinary = new UserMainWindowDictinary();

        private void GetUsersList()
            => this.UsersList = new UsersList();

        public bool ContainUser(string username, string password)
            => this.UsersList.IsContainUser(username, password);


        private void ExecuteExitApp(object obj)
            => Application.Current.Shutdown();

        /*private void ExecuteCheckedAction(object obj)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[IsKeepMeLoggedInKey].Value = (!IsChecked).ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }*/

        internal BaseMainWindowViewModel GetCorrespondingViewModel(string role)
            => this.UserMainWindowDictinary.GetCorrespondingMainWindowViewModel(role);

        internal string GetUserRole(string username, string password)
            => this.UsersList.GetUserRole(username, password);
    }
}
