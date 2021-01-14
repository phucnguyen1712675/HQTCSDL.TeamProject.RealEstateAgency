using CakeShopApp.Utils;
using HQTCSDL.TeamProject.RealEstateAgency.Model;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class AgencyContentViewModel : BaseViewModel
    {
        public ObservableCollection<Agency> AgenciesCollection { get; set; }
        public AddNewAgencyDialogViewModel AddNewAgencyDialogViewModel { get; set; }
        public ChangeAllSalaryByPercentDialogViewModel ChangeAllSalaryByPercentDialogViewModel { get; set; }
        public EachMonthCharityMoneyDialogViewModel EachMonthCharityMoneyDialogViewModel { get; set; }
        public ICommand RunAddNewAgencyDialogCommand => new AnotherCommandImplementation(ExecutAddNewAgencyDialog);
        public ICommand RunDeleteAgencyDialogCommand => new AnotherCommandImplementation(ExecuteDeleteAgencyDialog);
        public ICommand RunDoCharityDialogCommand => new AnotherCommandImplementation(ExecuteDoCharityDialog);
        public ICommand RunChangeSalaryDialogCommand => new AnotherCommandImplementation(ExecuteChangeSalaryDialog);

        public AgencyContentViewModel()
        {
            this.AgenciesCollection = (new AgenciesList()).GetAgenciesCollection();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");


        private async void ExecutAddNewAgencyDialog(object obj)
        {
            this.AddNewAgencyDialogViewModel = new AddNewAgencyDialogViewModel
            {
                SelectedAgency = new Agency()
            };

            var view = new AddNewAgencyDialog
            {
                DataContext = this.AddNewAgencyDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewAgencyClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteAgencyDialog(object obj)
        {
            var okeCancelDialogViewModel = new OkCancelDialogViewModel
            {
                Message = "Xóa chi nhánh này?"
            };

            var view = new OkCancelDialogControl
            {
                DataContext = okeCancelDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteChangeSalaryDialog(object obj)
        {
            this.ChangeAllSalaryByPercentDialogViewModel = new ChangeAllSalaryByPercentDialogViewModel();

            var view = new ChangeAllSalaryByPercentDialog
            {
                DataContext = this.ChangeAllSalaryByPercentDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, ChangeSalryClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDoCharityDialog(object obj)
        {
            this.EachMonthCharityMoneyDialogViewModel = new EachMonthCharityMoneyDialogViewModel();

            var view = new EachMonthCharityMoneyDialog()
            {
                DataContext = this.EachMonthCharityMoneyDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DoCharityClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewAgencyClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;
        }

        private void DoCharityClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;
        }

        private void ChangeSalryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;
        }

        #endregion
    }
}
