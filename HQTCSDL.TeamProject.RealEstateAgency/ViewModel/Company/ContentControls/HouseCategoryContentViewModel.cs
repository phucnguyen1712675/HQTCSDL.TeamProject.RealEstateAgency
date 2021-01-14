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
    public class HouseCategoryContentViewModel : BaseViewModel
    {
        public ObservableCollection<HouseCategory> HouseCateCollection {get; set;}
        public AddNewHouseCategoryDialogViewModel AddNewHouseCategoryDialogViewModel { get; set; }
        public DeleteAKindOfHouseDialogViewModel DeleteAKindOfHouseDialogViewModel { get; set; }
        public UpdateAKindOfHouseDialogViewModel UpdateAKindOfHouseDialogViewModel { get; set; }
        public ICommand RunAddNewHouseCategoryDialogCommand => new AnotherCommandImplementation(ExecuteAddNewHouseCategoryDialog);
        public ICommand RunDeleteHouseCategoryDialogCommand => new AnotherCommandImplementation(ExecuteDeleteHouseCategoryDialog);
        public ICommand RunUpdateHouseCategoryDialogCommand => new AnotherCommandImplementation(ExecuteUpdateHouseCategoryDialog);

        public HouseCategoryContentViewModel()
        {
            this.HouseCateCollection = (new HouseCategoriesList()).GetHouseCategoriesList();
        }

        #region Dialogs

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private async void ExecuteAddNewHouseCategoryDialog(object obj)
        {
            this.AddNewHouseCategoryDialogViewModel = new AddNewHouseCategoryDialogViewModel();

            var view = new AddNewHouseCategoryDialog
            {
                DataContext = this.AddNewHouseCategoryDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, AddNewHouseCategoryClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteDeleteHouseCategoryDialog(object obj)
        {
            this.DeleteAKindOfHouseDialogViewModel = new DeleteAKindOfHouseDialogViewModel();

            var view = new DeleteAKindOfHouseDialog
            {
                DataContext = this.DeleteAKindOfHouseDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private async void ExecuteUpdateHouseCategoryDialog(object obj)
        {
            this.UpdateAKindOfHouseDialogViewModel = new UpdateAKindOfHouseDialogViewModel();

            var view = new UpdateAKindOfHouseDialog
            {
                DataContext = this.UpdateAKindOfHouseDialogViewModel
            };

            //show the dialog
            var result = await DialogHost.Show(view, BaseMainWindowViewModel.Instance.Identifier, ExtendedOpenedEventHandler, UpdateExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void AddNewHouseCategoryClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        private void UpdateExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;
        }

        #endregion
    }
}
