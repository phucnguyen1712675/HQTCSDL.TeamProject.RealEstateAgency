using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void btnLogin_Click(object sender, RoutedEventArgs e) => CheckForLogin();

        private void CheckForLogin()
        {
            if (VerifyUser(txtUsername.Text, txtPassword.Password))
            {
                var homeScreen = new HomeScreen();
                App.Current.MainWindow = homeScreen;
                this.Close();
                homeScreen.Show();
            }
            else
            {
                MessageBox.Show("Username or password is incorrect", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool VerifyUser(string username, string password) => this.viewModel.ContainUser(username, password);

        private void MetroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CheckForLogin();
            }
        }
    }
}
