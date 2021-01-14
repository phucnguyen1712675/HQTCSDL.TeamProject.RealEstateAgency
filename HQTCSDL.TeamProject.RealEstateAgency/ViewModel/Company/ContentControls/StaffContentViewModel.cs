using CakeShopApp.Utils;
using HQTCSDL.TeamProject.RealEstateAgency.Model;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class StaffContentViewModel : BaseViewModel
    {
        public EmployeesList EmployeesList { get; set; }
        public DateTime Today { get; set; }
        public Employee SelectedEmployee { get; set; }
        public ObservableCollection<int> HasEmployeesAgencyList { get; set; }
        public AddNewEmployeeDialogViewModel AddNewEmployeeDialogViewModel { get; set; }
        public ChangeSalaryOfAEmployeeByPercentDialogViewModel ChangeSalaryOfAEmployeeByPercentDialogViewModel { get; set; }
        public ICommand RunAddNewEmployeeDialogCommand => new AnotherCommandImplementation(ExecuteAddNewEmployeeDialog);
        public ICommand RunDeleteEmployeeDialogCommand => new AnotherCommandImplementation(ExecuteDeleteEmployeeDialog);
        public ICommand RunChangeSalaryDialogCommand => new AnotherCommandImplementation(ExecuteChangeSalaryDialog);

        public StaffContentViewModel()
        {
            this.EmployeesList = new EmployeesList();

            var agenciesIdList = EmployeesList.GetEmployeesList().Select(c => c.AgencyId).Distinct().ToList();
            this.HasEmployeesAgencyList = new ObservableCollection<int>(agenciesIdList);

            this.Today = DateTime.Now;
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private async void ExecuteAddNewEmployeeDialog(object obj)
        {
            this.AddNewEmployeeDialogViewModel = new AddNewEmployeeDialogViewModel
            {
                SelectedEmployee = new Employee()
            };

            var view = new AddNewEmployeeDialog
            {
                DataContext = this.AddNewEmployeeDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteEmployeeDialog(object obj)
        {
            var okCancelDialogVm = new OkCancelDialogViewModel()
            {
                Message = "Xóa nhân viên này?"
            };

            var view = new OkCancelDialogControl()
            {
                DataContext = okCancelDialogVm
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteChangeSalaryDialog(object obj)
        {
            this.ChangeSalaryOfAEmployeeByPercentDialogViewModel = new ChangeSalaryOfAEmployeeByPercentDialogViewModel();

            var view = new ChangeSalaryOfAEmployeeByPercentDialog()
            {
                DataContext = this.ChangeSalaryOfAEmployeeByPercentDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, SalaryExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        private void SalaryExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        #endregion
    }
}
