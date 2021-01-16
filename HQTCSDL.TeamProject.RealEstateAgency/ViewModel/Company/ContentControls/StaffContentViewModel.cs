using Force.DeepCloner;
using GalaSoft.MvvmLight.Command;
using HQTCSDL.TeamProject.RealEstateAgency.DAO;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs.Staff;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.PagingHelperClasses;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.Staff;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class StaffContentViewModel : BaseViewModel
    {
        private const int rowsPerPage = 3;
        private readonly bool _canExecuteMyCommand;
        private NHANVIEN modifiedStaff;
        private readonly Paging _paging;
        private ObservableCollection<NHANVIEN> allStaffs;
        private ObservableCollection<CHINHANH> allAgencies;

        public int FilledSelectedIndex { get; set; }
        public int PagingSelectedIndex { get; set; }
        public ObservableCollection<PageInfo> Pages { get; set; }
        public ObservableCollection<NHANVIEN> StaffsCollection { get; set; }
        public ObservableCollection<CHINHANH> HasEmployeesAgencyCollection { get; set; }
        public StaffDetailViewModel StaffDetailViewModel { get; set; }
        public ICommand RunAddNewStaffCommand { get; }
        public ICommand RunEditStaffCommand { get; }
        public ICommand RunDeleteStaffCommand { get; }
        public ICommand PreviousCommand { get; }
        public ICommand NextCommand { get; }
        public ICommand SelectionChangedFilledComboBoxCommand { get; }
        public ICommand SelectionChangedPagingComboBoxCommand { get; }

        public StaffContentViewModel()
        {
            this._paging = new Paging();
            this.FilledSelectedIndex = 0;
            this.PagingSelectedIndex = 0;
            this._canExecuteMyCommand = true;
            Load();
            using var db = new QUANLYNHADATEntities();
            var tempAllAgencies = db.CHINHANHs.ToList();
            var satisfiedAgencies = tempAllAgencies.Where(a => a.NHANVIENs.Count > 0).ToList();
            this.HasEmployeesAgencyCollection = new ObservableCollection<CHINHANH>(satisfiedAgencies);
            this.RunAddNewStaffCommand = new RelayCommand(ExecuteAddNewStaffCommand, () => _canExecuteMyCommand);
            this.RunEditStaffCommand = new RelayCommand<object>(a => ExecuteEditStaffCommand(a), (_) => _canExecuteMyCommand);
            this.RunDeleteStaffCommand = new RelayCommand<object>(a => ExecuteDeleteStaffCommand(a), (_) => _canExecuteMyCommand);
            this.PreviousCommand = new RelayCommand(ExecutePreviousCommand, () => _canExecuteMyCommand);
            this.NextCommand = new RelayCommand(ExecuteNextCommand, () => _canExecuteMyCommand);
            this.SelectionChangedFilledComboBoxCommand = new RelayCommand(ExecuteSelectionFilledPagingComboBoxCommand, () => _canExecuteMyCommand);
            this.SelectionChangedPagingComboBoxCommand = new RelayCommand(ExecuteSelectionChangedPagingComboBoxCommand, () => _canExecuteMyCommand);
            ExecuteSelectionFilledPagingComboBoxCommand();
        }

        private void Load()
        {
            this.allStaffs = NhanVienDAO.GetInstance().GetAllStaffs();
            this.allAgencies = ChiNhanhDAO.GetInstance().GetAllAgencies();
        }

        private void ExecutePreviousCommand()
        {
            --this.PagingSelectedIndex;
            DisplayEmployees();
        }
        private void ExecuteNextCommand()
        {
            ++this.PagingSelectedIndex;
            DisplayEmployees();
        }
        private void ExecuteSelectionFilledPagingComboBoxCommand()
        {
            CaculatePagingInfo();
            DisplayEmployees();
        }
        private void ExecuteSelectionChangedPagingComboBoxCommand() => DisplayEmployees();

        private void CaculatePagingInfo()
        {
            var agencyID = this.HasEmployeesAgencyCollection[this.FilledSelectedIndex].MACN;
            var query = this.allStaffs.Where(e => e.MACN == agencyID).ToList();
            var count = query.Count;

            this.Pages = (new Paging()
            {
                CurrentPage = 1,
                RowsPerPage = rowsPerPage,
                TotalPages = (count / rowsPerPage) + (((count % rowsPerPage) == 0) ? 0 : 1)
            }).Pages;

            this.PagingSelectedIndex = 0;
        }

        private void DisplayEmployees()
        {
            var page = this.PagingSelectedIndex + 1;
            var agencyID = this.HasEmployeesAgencyCollection[this.FilledSelectedIndex].MACN;
            var skip = (page - 1) * rowsPerPage;
            const int take = rowsPerPage;
            var query = this.allStaffs.Where(e => e.MACN == agencyID).ToList();
            this.StaffsCollection = new ObservableCollection<NHANVIEN>();
            var tempList = query.Skip(skip).Take(take).ToList();
            tempList.ForEach(s =>
            {
                this.StaffsCollection.Add(s.DeepClone());
            });
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private async void ExecuteAddNewStaffCommand()
        {
            this.StaffDetailViewModel = new StaffDetailViewModel
            {
                SelectedStaff = new NHANVIEN(),
                AgenciesCollection = this.allAgencies
            };

            var view = new StaffDetailDialog
            {
                DataContext = this.StaffDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewStaffClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }
        private async void ExecuteEditStaffCommand(object key)
        {
            var values = (object[])key;
            this.modifiedStaff = NhanVienDAO.GetInstance().GetStaffById(values);

            this.StaffDetailViewModel = new StaffDetailViewModel
            {
                SelectedStaff = this.modifiedStaff,
                AgenciesCollection = this.allAgencies
            };

            var view = new StaffDetailDialog
            {
                DataContext = this.StaffDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, EditStaffClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteStaffCommand(object key)
        {
            var values = (object[])key;
            this.modifiedStaff = NhanVienDAO.GetInstance().GetStaffById(values);

            var okCancelDialogVm = new OkCancelDialogViewModel()
            {
                Message = "Xóa nhân viên này?"
            };

            var view = new OkCancelDialogControl()
            {
                DataContext = okCancelDialogVm
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewStaffClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            var staff = this.StaffDetailViewModel.SelectedStaff;
            NhanVienDAO.GetInstance().AddNewStaff(staff);
            Load();
            ExecuteSelectionFilledPagingComboBoxCommand();
        }

        private void EditStaffClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
               parameter == false) return;

            NhanVienDAO.GetInstance().EditStaff(this.StaffDetailViewModel.SelectedStaff);
            Load();
            ExecuteSelectionFilledPagingComboBoxCommand();
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            NhanVienDAO.GetInstance().DeleteStaff(this.StaffDetailViewModel.SelectedStaff);
            Load();
            ExecuteSelectionFilledPagingComboBoxCommand();
        }

        #endregion
    }
}
