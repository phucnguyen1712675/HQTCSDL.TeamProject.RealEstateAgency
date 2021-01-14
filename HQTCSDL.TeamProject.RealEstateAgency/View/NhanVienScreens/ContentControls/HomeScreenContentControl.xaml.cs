using PropertyChanged;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace HQTCSDL.TeamProject.RealEstateAgency.View.NhanVienScreens.ContentControls
{
    /// <summary>
    /// Interaction logic for HomeScreenContentControl.xaml
    /// </summary>
    public partial class HomeScreenContentControl : UserControl
    {
        public HomeScreenContentControl()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = Employee.GetEmployees();
            dataGrid2.ItemsSource = Employee.GetEmployees();
            dataGrid3.ItemsSource = Employee.GetEmployees();
            dataGrid4.ItemsSource = Employee.GetEmployees();
        }

        [AddINotifyPropertyChangedInterface]
        public class Employee
        {
            /* private string Address;
             private string Type;
             private string NumberRoom;
             private string Price;
             private string StarDate;
             private string EndDate;
             private string NumberView;*/
            public string Comment { get; set; }
            public string Code { get; set; }
            public string Title { get; set; }
            public bool WasEmpty { get; set; }
            public static ObservableCollection<Employee> GetEmployees()
            {
                var employees = new ObservableCollection<Employee>();

                employees.Add(new Employee()
                {
                    Code = "NHA001",
                    Title = "Minister",
                    WasEmpty = true,
                    Comment = "test comment 1"
                });
                return employees;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
