using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using MaterialDesignExtensions.Controls;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MaterialWindow
    {
        private const string IsKeepMeLoggedInKey = "IsKeepMeLoggedIn";

        //private const string HasSuccessfullyLoggedInKey = "HasSuccessfullyLoggedIn";

        private const string UserRoleKey = "UserRole";

        public LoginView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) 
            => DragMove();

        private bool VerifyUser(string username, string password)
        {
            if (DataContext is LoginViewModel dataContext)
            {
                return dataContext.ContainUser(username, password);
            }
            return false;
        }

        private void ShowMainWindow(BaseMainWindowViewModel viewModel)
        {
            var mainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            App.Current.MainWindow = mainWindow;
            this.Close();
            mainWindow.Show();
        }

        private void SetKeepMeLoggedIn(bool value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[IsKeepMeLoggedInKey].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }

        /*private void SetHasSuccessfullyLoggedIn(bool value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[HasSuccessfullyLoggedInKey].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }*/

        private void SetUserRole(string role)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[UserRoleKey].Value = role;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private bool CheckForLogin()
        {
            bool result = false;

            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var hasVerified = VerifyUser(username, password);

            if (hasVerified)
            {
                if (DataContext is LoginViewModel dataContext)
                {
                    var isKeepMeLoggedInChecked = dataContext.IsChecked;
                    var userRole = dataContext.GetUserRole(username, password);

                    if (isKeepMeLoggedInChecked)
                    {
                        SetKeepMeLoggedIn(true);
                    }

                    if (userRole != null)
                    {
                        var correspondingViewModel = dataContext.GetCorrespondingViewModel(userRole);

                        if (correspondingViewModel != null)
                        {
                            SetUserRole(userRole);
                            ShowMainWindow(correspondingViewModel);

                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        private void AutoLoginAccountChecking()
            => CheckForLogin();

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) 
            => AutoLoginAccountChecking();

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e) 
            => AutoLoginAccountChecking();

        private void MaterialWindow_Loaded(object sender, RoutedEventArgs e)
            => txtUsername.Focus();

        private void MaterialWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var result = CheckForLogin();

                if (!result)
                {
                    MessageBox.Show("Wrong username or password!");
                }
            }
        }
    }
}
