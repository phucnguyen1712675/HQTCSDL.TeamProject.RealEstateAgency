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
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public static int NextId = 1;

#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public ObservableCollection<EmployeesModel> EmployeesList { get; set; } =
            new ObservableCollection<EmployeesModel>()
        {
                new EmployeesModel(1, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(1, "Nguyen Van B", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(1, "Nguyen Van C", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(1, "Nguyen Van D", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(1, "Nguyen Van E", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(2, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(3, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(5, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0)
        };
        public ObservableCollection<int> HasEmployeesAgencyList { get; set; }
        public EmployeesViewModel() => HasEmployeesAgencyList = new ObservableCollection<int>(EmployeesList.Select(c => c.AgencyId).Distinct().ToList());
        public void AddNewEmployee(EmployeesModel newEmployee) => this.EmployeesList.Add(newEmployee);
        public void RemoveEmployee(EmployeesModel oldEmployee) => this.EmployeesList.Remove(oldEmployee);
        public DateTime Today { get; set; } = DateTime.Now;

        public ICommand RunDialogCommand => new AnotherCommandImplementation(ExecuteRunDialog);

        public ICommand RunExtendedDialogCommand => new AnotherCommandImplementation(ExecuteRunExtendedDialog);

        private async void ExecuteRunDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddNewEmployeeDialog
            {
                DataContext = new AddNewEmployeeDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
            => Console.WriteLine("You can intercept the closing event, and cancel here.");

        private async void ExecuteRunExtendedDialog(object o)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new AddNewEmployeeDialog
            {
                DataContext = new AddNewEmployeeDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "RootDialog", ExtendedOpenedEventHandler, ExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");

        private void ExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

            var viewModel = new AddNewEmployeeDialogViewModel();
            AddNewEmployee(new EmployeesModel
                (
                    viewModel.AgencyId,
                    viewModel.FullName,
                    viewModel.PhoneNumber,
                    viewModel.Address,
                    viewModel.Sex,
                    viewModel.DOB,
                    viewModel.Salary
                ));

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
