using GalaSoft.MvvmLight.Command;
using HQTCSDL.TeamProject.RealEstateAgency.DAO;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs.Agency;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.Agency;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class AgencyContentViewModel : BaseViewModel
    {
        private readonly bool _canExecuteMyCommand;
        private CHINHANH ModifiedAgency;

        public ObservableCollection<CHINHANH> AgenciesCollection { get; set; }
        public AgencyDetailViewModel AgencyDetailViewModel { get; set; }
        public ChangeAllSalaryByPercentDialogViewModel ChangeAllSalaryByPercentDialogViewModel { get; set; }
        public EachMonthCharityMoneyDialogViewModel EachMonthCharityMoneyDialogViewModel { get; set; }
        public ICommand RunAddNewAgencyCommand { get; }
        public ICommand RunEditAgencyCommand { get; }
        public ICommand RunDeleteAgencyCommand { get; }
        /* public ICommand RunDoCharityCommand { get; }
         public ICommand RunChangeSalaryCommand { get; }*/

        public AgencyContentViewModel()
        {
            this._canExecuteMyCommand = true;
            this.RunAddNewAgencyCommand = new RelayCommand(ExecuteAddNewAgencyCommand, () => _canExecuteMyCommand);
            this.RunEditAgencyCommand = new RelayCommand<int>(a => ExecuteEditAgencyCommand(a), (_) => _canExecuteMyCommand);
            this.RunDeleteAgencyCommand = new RelayCommand<int>(a => ExecuteDeleteAgencyCommand(a), (_) => _canExecuteMyCommand);
            Load();
        }

        private void Load()
        {
            this.AgenciesCollection = ChiNhanhDAO.GetInstance().GetAllAgencies();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");


        private async void ExecuteAddNewAgencyCommand()
        {
            this.AgencyDetailViewModel = new AgencyDetailViewModel
            {
                SelectedAgency = new CHINHANH()
            };

            var view = new AgencyDetailDialog
            {
                DataContext = this.AgencyDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewAgencyClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteEditAgencyCommand(int agencyId)
        {
            this.ModifiedAgency = ChiNhanhDAO.GetInstance().GetAgencyById(agencyId);

            this.AgencyDetailViewModel = new AgencyDetailViewModel
            {
                SelectedAgency = this.ModifiedAgency
            };

            var view = new AgencyDetailDialog
            {
                DataContext = this.AgencyDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, EditAgencyClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteAgencyCommand(int agencyId)
        {
            this.ModifiedAgency = ChiNhanhDAO.GetInstance().GetAgencyById(agencyId);

            var okeCancelDialogViewModel = new OkCancelDialogViewModel
            {
                Message = "Xóa chi nhánh này?"
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

        /* private async void ExecuteChangeSalaryDialog(object obj)
         {
             this.ChangeAllSalaryByPercentDialogViewModel = new ChangeAllSalaryByPercentDialogViewModel();

             var view = new ChangeAllSalaryByPercentDialog
             {
                 DataContext = this.ChangeAllSalaryByPercentDialogViewModel
             };

             //show the dialog
             var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, ChangeSalryClosingEventHandler).ConfigureAwait(false);

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
             var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DoCharityClosingEventHandler).ConfigureAwait(false);

             //check the result...
             Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
         }
 */
        private void AddNewAgencyClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            var agency = this.AgencyDetailViewModel.SelectedAgency;
            ChiNhanhDAO.GetInstance().AddNewAgency(agency);
            Load();
        }

        private void EditAgencyClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            ChiNhanhDAO.GetInstance().EditAgency(this.ModifiedAgency);
            Load();
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            ChiNhanhDAO.GetInstance().DeleteAgency(this.ModifiedAgency);
            Load();
        }

        /*  private void DoCharityClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
          {
              if (eventArgs.Parameter is bool parameter &&
                  !parameter) return;
          }

          private void ChangeSalryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
          {
              if (eventArgs.Parameter is bool parameter &&
                  !parameter) return;
          }*/

        #endregion
    }
}
