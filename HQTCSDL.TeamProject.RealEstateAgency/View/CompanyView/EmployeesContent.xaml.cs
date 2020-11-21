using HQTCSDL.TeamProject.RealEstateAgency.Model;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.PagingHelperClasses;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView
{
    /// <summary>
    /// Interaction logic for EmployeesContent.xaml
    /// </summary>
    public partial class EmployeesContent : UserControl
    {
        public EmployeesContent() => InitializeComponent();

        private void FilledComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            caculatePagingInfo();
            displayEmployees();
        }

        private Paging _paging;
        private const int rowsPerPage = 4;
        private void caculatePagingInfo()
        {
            var agencyID = int.Parse(FilledComboBox.SelectedItem.ToString());

            var query = from e in ((EmployeesViewModel)this.DataContext).EmployeesList
                        where e.AgencyId == agencyID
                        select e;

            var count = query.Count();

            _paging = new Paging()
            {
                CurrentPage = 1,
                RowsPerPage = rowsPerPage,
                TotalPages = count / rowsPerPage +
                    (((count % rowsPerPage) == 0) ? 0 : 1)
            };

            pagingInfoComboBox.ItemsSource = _paging.Pages;
            pagingInfoComboBox.SelectedIndex = 0;
        }

        private ObservableCollection<EmployeesModel> filledEmployeesList;
        private void displayEmployees()
        {
            var page = pagingInfoComboBox.SelectedIndex + 1;
            var agencyID = int.Parse(FilledComboBox.SelectedItem.ToString());
            var skip = (page - 1) * rowsPerPage;
            var take = rowsPerPage;

            var query = from e in ((EmployeesViewModel)this.DataContext).EmployeesList
                        where e.AgencyId == agencyID
                        select e;

            filledEmployeesList = new ObservableCollection<EmployeesModel>(query
                .Skip(skip).Take(take)
                .ToList());
            EmployeeListView.ItemsSource = filledEmployeesList;
        }

        private void pagingInfoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) => displayEmployees();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FilledComboBox.ItemsSource = ((EmployeesViewModel)this.DataContext).HasEmployeesAgencyList;
            FilledComboBox.SelectedIndex = 0;
        }

        private void previousButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagingInfoComboBox.SelectedIndex > 0)
            {
                pagingInfoComboBox.SelectedIndex -= 1;
            }
            else
            {
                MessageBox.Show("Minimum page!", "Reach Minimum page", MessageBoxButton.OKCancel);
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagingInfoComboBox.SelectedIndex < pagingInfoComboBox.Items.Count - 1)
            {
                pagingInfoComboBox.SelectedIndex += 1;
            }
            else
            {
                MessageBox.Show("Maximum page!", "Reach Maximum page", MessageBoxButton.OKCancel);
            }
        }
    }
}
