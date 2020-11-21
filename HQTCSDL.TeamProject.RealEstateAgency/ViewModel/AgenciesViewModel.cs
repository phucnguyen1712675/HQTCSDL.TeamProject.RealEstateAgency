using HQTCSDL.TeamProject.RealEstateAgency.Model;
using HQTCSDL.TeamProject.RealEstateAgency.View.CompanyView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.DialogsHelperClasses;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class AgenciesViewModel : INotifyPropertyChanged
    {
        public static int NextId = 1;
        public ObservableCollection<AgenciesModel> AgenciesList { get; set; } =
            new ObservableCollection<AgenciesModel>()
        {
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS"),
                new AgenciesModel("123456789", "0985897654", "HCMUS")
        };

#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public void AddNewAgency(AgenciesModel newAgency) => this.AgenciesList.Add(newAgency);
        public void RemoveAgency(AgenciesModel oldAgency) => this.AgenciesList.Remove(oldAgency);

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        public ICommand RunExtendedDialogCommand => new AnotherCommandImplementation(ExecuteRunExtendedDialog);

        public ICommand RunDeleteExtendedDialogCommand => new AnotherCommandImplementation(ExecuteDeleteRunExtendedDialog);

        private async void ExecuteDeleteRunExtendedDialog(object obj)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new DeleteAgencyDialog
            {
                //DataContext = new DeleteAgencyViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "AgenciesRootDialog", DeleteExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void DeleteExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            //----------------------------------

            //OK, lets cancel the close...
            eventArgs.Cancel();

            //...now, lets update the "session" with some new content!
            eventArgs.Session.UpdateContent(new SampleProgressDialog());
            //note, you can also grab the session when the dialog opens via the DialogOpenedEventHandler

            //lets run a fake operation for 3 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddNewAgencyDialog
            {
                DataContext = new AddNewAgencyDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "AgenciesRootDialog", ClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
            => Console.WriteLine("You can intercept the closing event, and cancel here.");

        private async void ExecuteRunExtendedDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddNewAgencyDialog
            {
                DataContext = new AddNewAgencyDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "AgenciesRootDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            /*var viewModel = new AddNewEmployeeDialogViewModel();
            AddNewEmployee(new EmployeesModel
                (
                    viewModel.AgencyId,
                    viewModel.FullName,
                    viewModel.PhoneNumber,
                    viewModel.Address,
                    viewModel.Sex,
                    viewModel.DOB,
                    viewModel.Salary
                ));*/

            //OK, lets cancel the close...
            eventArgs.Cancel();

            //...now, lets update the "session" with some new content!
            eventArgs.Session.UpdateContent(new SampleProgressDialog());
            //note, you can also grab the session when the dialog opens via the DialogOpenedEventHandler

            //lets run a fake operation for 3 seconds then close this baby.
            Task.Delay(TimeSpan.FromSeconds(3))
                .ContinueWith((t, _) => eventArgs.Session.Close(false), null,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
