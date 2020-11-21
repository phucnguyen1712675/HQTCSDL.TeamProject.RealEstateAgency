using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class ChangeAllSalaryByPercentDialogViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public List<int> AllPercents { get; set; } = new List<int>();
        public int MaxPercent { get; set; } = 50;
        public int MinPercent { get; set; } = 10;
        public int StepPercent { get; set; } = 10;
        public ChangeAllSalaryByPercentDialogViewModel()
        {
            for (int i = this.MinPercent; i <= this.MaxPercent; i += this.StepPercent)
            {
                this.AllPercents.Add(i);
            }
        }
    }
}
