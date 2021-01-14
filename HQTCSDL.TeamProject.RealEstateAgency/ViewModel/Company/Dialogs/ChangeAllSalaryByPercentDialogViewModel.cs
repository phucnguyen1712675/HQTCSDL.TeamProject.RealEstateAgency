using System.Collections.Generic;
using System.Linq;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs
{
    public class ChangeAllSalaryByPercentDialogViewModel : BaseViewModel
    {
        public List<int> AllPercents { get; set; }
        public int MaxPercent { get; set; } = 50;
        public int MinPercent { get; set; } = 10;
        public int StepPercent { get; set; } = 10;
        public ChangeAllSalaryByPercentDialogViewModel()
        {
            this.AllPercents = new List<int>();

            foreach (var percent in Enumerable.Range(MinPercent, MaxPercent).Where(p => p % StepPercent == 0))
            {
                this.AllPercents.Add(percent);
            }
        }
    }
}
