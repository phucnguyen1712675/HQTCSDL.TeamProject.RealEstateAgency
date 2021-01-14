using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    [AddINotifyPropertyChangedInterface]
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int AgencyId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; } //true - Nam || false - Nu
        public DateTime DOB { get; set; }
        public double Salary { get; set; }
    }
}
