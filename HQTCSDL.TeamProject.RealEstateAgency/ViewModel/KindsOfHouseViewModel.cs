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
    public class KindsOfHouseViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public static int NextID = 1;

        public ObservableCollection<KindsOfHouseModel> KindsOfHousesList { get; set; } = new ObservableCollection<KindsOfHouseModel>()
        {
            new KindsOfHouseModel("Nhà 1 lầu"),
            new KindsOfHouseModel("Nhà 2 lầu"),
            new KindsOfHouseModel("Nhà 3 lầu"),
            new KindsOfHouseModel("Nhà chung cư"),
            new KindsOfHouseModel("Nhà trọ"),
            new KindsOfHouseModel("Nhà thổ cư")
        };

        public ICommand RunDeleteExtendedDialogCommand => new AnotherCommandImplementation(ExecuteDeleteRunExtendedDialog);
        public ICommand RunUpdateExtendedDialogCommand => new AnotherCommandImplementation(ExecuteUpdateRunExtendedDialog);

        private async void ExecuteUpdateRunExtendedDialog(object obj)
        {
            var view = new UpdateAKindOfHouseDialog
            {
                DataContext = new UpdateAKindOfHouseDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "HouseRootDialog", ExtendedOpenedEventHandler, UpdateExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void UpdateExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

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

        private async void ExecuteDeleteRunExtendedDialog(object obj)
        {
            //let's set up a little MVVM, cos that's what the cool kids are doing:
            var view = new DeleteAKindOfHouseDialog
            {
                DataContext = new DeleteAKindOfHouseDialogViewModel()
            };

            //show the dialog
            var result = await DialogHost.Show(view, "HouseRootDialog", ExtendedOpenedEventHandler, DeleteExtendedClosingEventHandler);

            //check the result...
            Console.WriteLine("Dialog was closed, the CommandParameter used to close it was: " + (result ?? "NULL"));
        }

        private void DeleteExtendedClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
        {
            if (eventArgs.Parameter is bool parameter &&
                parameter == false) return;

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

        private void ExtendedOpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
            => Console.WriteLine("You could intercept the open and affect the dialog using eventArgs.Session.");
    }
}
