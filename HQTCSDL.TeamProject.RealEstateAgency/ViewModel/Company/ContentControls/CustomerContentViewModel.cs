using GalaSoft.MvvmLight.Command;
using HQTCSDL.TeamProject.RealEstateAgency.DAO;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs.Customer;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.Customer;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class CustomerContentViewModel : BaseViewModel
    {
        private readonly bool _canExecuteMyCommand;
        private KHACHHANG ModifiedCustomer;
        private ObservableCollection<CHINHANH> allAgencies;

        public ObservableCollection<KHACHHANG> CustomersCollection { get; set; }
        public CustomerDetailViewModel CustomerDetailViewModel { get; set; }
        public ICommand RunAddNewCustomerCommand { get; }
        public ICommand RunEditCustomerCommand { get; }
        public ICommand RunDeleteCustomerCommand { get; }

        public CustomerContentViewModel()
        {
            this._canExecuteMyCommand = true;
            this.RunAddNewCustomerCommand = new RelayCommand(ExecuteAddNewCustomerCommand, () => _canExecuteMyCommand);
            this.RunEditCustomerCommand = new RelayCommand<object>(a => ExecuteEditCustomerCommand(a), (_) => _canExecuteMyCommand);
            this.RunDeleteCustomerCommand = new RelayCommand<object>(a => ExecuteDeleteCustomerCommand(a), (_) => _canExecuteMyCommand);
            Load();
        }

        private void Load()
        {
            this.CustomersCollection = KhachHangDAO.GetInstance().GetAllCustomers();
            this.allAgencies = ChiNhanhDAO.GetInstance().GetAllAgencies();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");


        private async void ExecuteAddNewCustomerCommand()
        {
            this.CustomerDetailViewModel = new CustomerDetailViewModel
            {
                SelectedCustomer = new KHACHHANG(),
                AgenciesCollection = this.allAgencies
            };

            var view = new CustomerDetailDialog
            {
                DataContext = this.CustomerDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewCustomerClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteEditCustomerCommand(object key)
        {
            var values = (object[])key;
            this.ModifiedCustomer = KhachHangDAO.GetInstance().GetCustomerById(values);

            this.CustomerDetailViewModel = new CustomerDetailViewModel
            {
                SelectedCustomer = this.ModifiedCustomer,
                AgenciesCollection = this.allAgencies
            };

            var view = new CustomerDetailDialog
            {
                DataContext = this.CustomerDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, EditCustomerClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteCustomerCommand(object key)
        {
            var values = (object[])key;
            this.ModifiedCustomer = KhachHangDAO.GetInstance().GetCustomerById(values);

            var okeCancelDialogViewModel = new OkCancelDialogViewModel
            {
                Message = "Xóa khách hàng này?"
            };

            var view = new OkCancelDialogControl
            {
                DataContext = okeCancelDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewCustomerClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            var Customer = this.CustomerDetailViewModel.SelectedCustomer;
            KhachHangDAO.GetInstance().AddNewCustomer(Customer);
            Load();
        }

        private void EditCustomerClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            KhachHangDAO.GetInstance().EditCustomer(this.ModifiedCustomer);
            Load();
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            KhachHangDAO.GetInstance().DeleteCustomer(this.ModifiedCustomer);
            Load();
        }

        #endregion
    }
}
