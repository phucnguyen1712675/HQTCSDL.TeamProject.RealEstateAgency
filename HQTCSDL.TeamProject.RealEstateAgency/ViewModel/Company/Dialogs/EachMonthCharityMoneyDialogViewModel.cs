using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company.Dialogs
{
    public class EachMonthCharityMoneyDialogViewModel : BaseViewModel
    {
        public List<string> AllMonths { get; }
        public string SelectedMonth { get; set; }
        public int SelectedIndex { get; set; }
        public List<int> AllPercents { get; set; }
        public int MaxPercent { get; set; } = 50;
        public int MinPercent { get; set; } = 10;
        public int StepPercent { get; set; } = 10;
        public EachMonthCharityMoneyDialogViewModel()
        {
            this.AllMonths = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();

            this.SelectedMonth = DateTime.Now.Month.ToString();

            this.SelectedIndex = this.AllMonths.FindIndex(c => c.Equals(this.SelectedMonth));

            this.AllPercents = new List<int>();

            foreach (var percent in Enumerable.Range(MinPercent, MaxPercent).Where(p => p % StepPercent == 0))
            {
                this.AllPercents.Add(percent);
            }
        }
    }
}
