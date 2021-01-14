using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.ContentControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs
{
    public class ChangeSalaryOfAEmployeeByPercentDialogViewModel : BaseViewModel
    {
        public ObservableCollection<int> EmployeesList { get; }
        public List<int> AllPercents { get; set; }
        public int MaxPercent { get; set; } = 50;
        public int MinPercent { get; set; } = 10;
        public int StepPercent { get; set; } = 10;
        public ChangeSalaryOfAEmployeeByPercentDialogViewModel()
        {
            this.AllPercents = new List<int>();

            foreach (var percent in Enumerable.Range(MinPercent, MaxPercent).Where(p => p % StepPercent == 0))
            {
                this.AllPercents.Add(percent);
            }

            var viewModel = new StaffContentViewModel();
            var list = viewModel.EmployeesList.GetEmployeesList().Select(c => c.EmployeeId).ToList();
            this.EmployeesList = new ObservableCollection<int>(list);
        }
    }
}
