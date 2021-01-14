using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using MaterialDesignExtensions.Controls;
using MaterialDesignExtensions.Model;
using System.Configuration;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        private const string IsKeepMeLoggedInKey = "IsKeepMeLoggedIn";

        public static MainWindow Instance;

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void NavigationItemSelectedHandler(object sender, NavigationItemSelectedEventArgs args)
            => SelectNavigationItem(args.NavigationItem);

        public void SetContentControl(object newContent)
            => contentControl.Content = newContent;

        private void SelectNavigationItem(INavigationItem navigationItem)
        {
            if (navigationItem != null)
            {
                object newContent = navigationItem.NavigationItemSelectedCallback(navigationItem);

                if (contentControl.Content == null || contentControl.Content.GetType() != newContent.GetType())
                {
                    SetContentControl(newContent);
                }
            }
            else
            {
                SetContentControl(null);
            }

            if (appBar != null)
            {
                appBar.IsNavigationDrawerOpen = false;
            }
        }

        private void SetKeepMeLoggedIn(bool value)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[IsKeepMeLoggedInKey].Value = value.ToString();
            config.Save(ConfigurationSaveMode.Minimal);
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            SetKeepMeLoggedIn(false);

            var loginView = new LoginView
            {
                DataContext = new LoginViewModel()
            };

            App.Current.MainWindow = loginView;
            this.Close();
            loginView.Show();
        }
    }
}
