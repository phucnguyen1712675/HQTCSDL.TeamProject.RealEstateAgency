using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HQTCSDL.TeamProject.RealEstateAgency.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : MetroWindow
    {
        private UsersViewModel viewModel { get; } = new UsersViewModel();

        public LoginView()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e) => DragMove();

        private void btnExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private bool VerifyUser(string username, string password) => this.viewModel.ContainUser(username, password);

        private bool CheckForLogin()
        {
            bool result = VerifyUser(txtUsername.Text, txtPassword.Password);
            if (result)
            {

                var homeScreen = new HomeScreen();
                App.Current.MainWindow = homeScreen;
                this.Close();
                homeScreen.Show();
            }
            return result;
        }

        private void ManuallyLoginAccountChecking()
        {
            bool result = CheckForLogin();
            if (!result)
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AutoLoginAccountChecking() => CheckForLogin();

        private void btnLogin_Click(object sender, RoutedEventArgs e) => ManuallyLoginAccountChecking();

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ManuallyLoginAccountChecking();
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) => AutoLoginAccountChecking();

        private void txtUsername_TextChanged(object sender, TextChangedEventArgs e) => AutoLoginAccountChecking();

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e) => txtUsername.Focus();
    }
}
