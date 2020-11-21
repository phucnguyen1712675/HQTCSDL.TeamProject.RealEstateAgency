using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
namespace HQTCSDL.TeamProject.RealEstateAgency.View.NhanVienScreens
{
    /// <summary>
    /// Interaction logic for NhanVienMain.xaml
    /// </summary>
    public partial class NhanVienMain : MetroWindow
    {
        public NhanVienMain()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = Employee.GetEmployees();
            dataGrid2.ItemsSource = Employee.GetEmployees();
            dataGrid3.ItemsSource = Employee.GetEmployees();
            dataGrid4.ItemsSource = Employee.GetEmployees();

        }

        public class Employee : INotifyPropertyChanged
        {
            private string code;
            private string comment;
           /* private string Address;
            private string Type;
            private string NumberRoom;
            private string Price;
            private string StarDate;
            private string EndDate;
            private string NumberView;*/
            public string Comment
            {
                get { return comment; }
                set
                {
                    comment = value;
                    RaiseProperChanged();
                }
            }
            public string Code
            {
                get { return code; }
                set
                {
                    code = value;
                    RaiseProperChanged();
                }
            }

            private string title;

            public string Title
            {
                get { return title; }
                set
                {
                    title = value;
                    RaiseProperChanged();
                }
            }

            private bool wasEmpty;

            public bool WasEmpty
            {
                get { return wasEmpty; }
                set
                {
                    wasEmpty = value;
                    RaiseProperChanged();
                }
            }


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

            public event PropertyChangedEventHandler PropertyChanged;

            private void RaiseProperChanged([CallerMemberName] string caller = "")
            {

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
