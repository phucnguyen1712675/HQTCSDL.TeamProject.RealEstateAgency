using HQTCSDL.TeamProject.RealEstateAgency.Model;
using HQTCSDL.TeamProject.RealEstateAgency.View;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System.Configuration;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string IsKeepMeLoggedInKey = "IsKeepMeLoggedIn";

        private const string UserRoleKey = "UserRole";

        private void ShowLoginView()
        {
            var loginScreen = new LoginView
            {
                DataContext = new LoginViewModel()
            };

            this.MainWindow = loginScreen;
            loginScreen.Show();
        }

        private void ShowMainWindow(BaseViewModel viewModel)
        {
            var mainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            this.MainWindow = mainWindow;
            mainWindow.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var isKeepMeLoggedIn = bool.Parse(ConfigurationManager.AppSettings[IsKeepMeLoggedInKey]);

            if (isKeepMeLoggedIn)
            {
                var result = false;
                var userRole = ConfigurationManager.AppSettings[UserRoleKey];

                if (userRole != null)
                {
                    var mainWindowVm = UserMainWindowDictinary.GetInstance().GetCorrespondingMainWindowViewModel(userRole);

                    if (mainWindowVm != null)
                    {
                        ShowMainWindow(mainWindowVm);

                        result = true;
                    }
                }

                if (!result)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                ShowLoginView();
            }
        }
    }
}
