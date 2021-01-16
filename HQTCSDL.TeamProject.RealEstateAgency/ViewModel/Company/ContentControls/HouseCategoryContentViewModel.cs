using GalaSoft.MvvmLight.Command;
using HQTCSDL.TeamProject.RealEstateAgency.DAO;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView.Dialogs.HouseCategory;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs.HouseCategory;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls
{
    public class HouseCategoryContentViewModel : BaseViewModel
    {
        private readonly bool _canExecuteMyCommand;
        private LOAINHA modifiedHouseCategory;

        public ObservableCollection<LOAINHA> HouseCategoriesCollection { get; set; }
        public HouseCategoryDetailViewModel HouseCategoryDetailViewModel { get; set; }
        public ICommand RunAddNewHouseCategoryCommand { get; }
        public ICommand RunEditHouseCategoryCommand { get; }
        public ICommand RunDeleteHouseCategoryCommand { get; }

        public HouseCategoryContentViewModel()
        {
            this._canExecuteMyCommand = true;
            this.RunAddNewHouseCategoryCommand = new RelayCommand(ExecuteAddNewHouseCategoryCommand, () => _canExecuteMyCommand);
            this.RunEditHouseCategoryCommand = new RelayCommand<int>(a => ExecuteEditHouseCategoryCommand(a), (_) => _canExecuteMyCommand);
            this.RunDeleteHouseCategoryCommand = new RelayCommand<int>(a => ExecuteDeleteHouseCategoryCommand(a), (_) => _canExecuteMyCommand);
            Load();
        }

        private void Load()
        {
            this.HouseCategoriesCollection = LoaiNhaDAO.GetInstance().GetAllHouseCategories();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private async void ExecuteAddNewHouseCategoryCommand()
        {
            this.HouseCategoryDetailViewModel = new HouseCategoryDetailViewModel
            {
                SelectedHouseCategory = new LOAINHA()
            };

            var view = new HouseCategoryDetailDialog
            {
                DataContext = this.HouseCategoryDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewHouseCategoryClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteEditHouseCategoryCommand(int cateId)
        {
            this.modifiedHouseCategory = LoaiNhaDAO.GetInstance().GetHouseCategoryById(cateId);

            this.HouseCategoryDetailViewModel = new HouseCategoryDetailViewModel
            {
                SelectedHouseCategory = this.modifiedHouseCategory
            };

            var view = new HouseCategoryDetailDialog
            {
                DataContext = this.HouseCategoryDetailViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, EditHouseCategoryClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteHouseCategoryCommand(int cateId)
        {
            this.modifiedHouseCategory = LoaiNhaDAO.GetInstance().GetHouseCategoryById(cateId);

            var okeCancelDialogViewModel = new OkCancelDialogViewModel
            {
                Message = "Xóa loại nhà này?"
            };

            var view = new OkCancelDialogControl
            {
                DataContext = okeCancelDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteHouseCategoryClosingEventHandler).ConfigureAwait(false);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewHouseCategoryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            var houseCate = this.HouseCategoryDetailViewModel.SelectedHouseCategory;
            LoaiNhaDAO.GetInstance().AddNewHouseCategory(houseCate);
            Load();
        }
        private void EditHouseCategoryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            LoaiNhaDAO.GetInstance().EditHouseCategory(this.HouseCategoryDetailViewModel.SelectedHouseCategory);
            Load();
        }

        private void DeleteHouseCategoryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            LoaiNhaDAO.GetInstance().DeleteHouseCategory(this.HouseCategoryDetailViewModel.SelectedHouseCategory);
            Load();
        }

        #endregion
    }
}
