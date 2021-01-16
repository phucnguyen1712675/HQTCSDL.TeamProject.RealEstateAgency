using GalaSoft.MvvmLight.Command;
using HQTCSDL.TeamProject.RealEstateAgency.DAO;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs.House;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.House;
using HQTCSDL.TeamProject.RealEstateHouseOwner.DAO;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class HouseContentViewModel : BaseViewModel
    {
        private readonly bool _canExecuteMyCommand;
        private NHA ModifiedHouse;
        private CHITIETNHATHUE ModifiedRentalHouseDetail;
        private ObservableCollection<CHINHANH> allAgencies;
        private ObservableCollection<CHUNHA> allHouseOwners;
        private ObservableCollection<NHANVIEN> allStaffs;
        private ObservableCollection<LOAINHA> allHouseCategories;

        public ObservableCollection<NHA> HousesCollection { get; set; }
        public HouseDetailViewModel HouseDetailViewModel { get; set; }
        public ICommand RunAddNewHouseCommand { get; }
        public ICommand RunEditHouseCommand { get; }
        public ICommand RunDeleteHouseCommand { get; }

        public HouseContentViewModel()
        {
            this._canExecuteMyCommand = true;
            this.RunAddNewHouseCommand = new RelayCommand(ExecuteAddNewHouseCommand, () => _canExecuteMyCommand);
            this.RunEditHouseCommand = new RelayCommand<object>(a => ExecuteEditHouseCommand(a), (_) => _canExecuteMyCommand);
            this.RunDeleteHouseCommand = new RelayCommand<object>(a => ExecuteDeleteHouseCommand(a), (_) => _canExecuteMyCommand);
            Load();
        }

        private void Load()
        {
            this.HousesCollection = NhaDAO.GetInstance().GetAllHouses();
            this.allAgencies = ChiNhanhDAO.GetInstance().GetAllAgencies();
            this.allHouseOwners = ChuNhaDAO.GetInstance().GetAllHousOwners();
            this.allStaffs = NhanVienDAO.GetInstance().GetAllStaffs();
            this.allHouseCategories = LoaiNhaDAO.GetInstance().GetAllHouseCategories();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");


        private async void ExecuteAddNewHouseCommand()
        {
            this.HouseDetailViewModel = new HouseDetailViewModel
            {
                SelectedHouse = new NHA(),
                AgenciesCollection = this.allAgencies,
                HouseOwnersCollection = this.allHouseOwners,
                StaffsCollection = this.allStaffs,
                HouseCatesCollection = this.allHouseCategories
            };

            var view = new HouseDetailDialog
            {
                DataContext = this.HouseDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewHouseClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteEditHouseCommand(object key)
        {
            var values = (object[])key;
            this.ModifiedHouse = NhaDAO.GetInstance().GetHouseById(values);
            this.ModifiedRentalHouseDetail = ChiTietNhaThueDAO.GetInstance().GetRentalhouseDetailById(values);

            this.HouseDetailViewModel = new HouseDetailViewModel
            {
                SelectedHouse = this.ModifiedHouse,
                SelectedRentalHouseDetail = this.ModifiedRentalHouseDetail,
                AgenciesCollection = this.allAgencies,
                HouseOwnersCollection = this.allHouseOwners,
                StaffsCollection = this.allStaffs,
                HouseCatesCollection = this.allHouseCategories
            };

            var view = new HouseDetailDialog
            {
                DataContext = this.HouseDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, EditHouseClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteHouseCommand(object key)
        {
            var values = (object[])key;
            this.ModifiedHouse = NhaDAO.GetInstance().GetHouseById(values);
            this.ModifiedRentalHouseDetail = ChiTietNhaThueDAO.GetInstance().GetRentalhouseDetailById(values);

            var okeCancelDialogViewModel = new OkCancelDialogViewModel
            {
                Message = "Xóa nhà này?"
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

        private void AddNewHouseClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            var House = this.HouseDetailViewModel.SelectedHouse;
            NhaDAO.GetInstance().AddNewHouse(House);
            Load();
        }

        private void EditHouseClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            ChiTietNhaThueDAO.GetInstance().EditRentalhouseDetail(this.ModifiedRentalHouseDetail);
            NhaDAO.GetInstance().EditHouse(this.ModifiedHouse);
            Load();
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                !parameter) return;

            ChiTietNhaThueDAO.GetInstance().DeleteRentalhouseDetail(this.ModifiedRentalHouseDetail);
            NhaDAO.GetInstance().DeleteHouse(this.ModifiedHouse);
            Load();
        }

        #endregion
    }
}