using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class EmployeesModel : INotifyPropertyChanged
    {
        public EmployeesModel(int agencyId, string fullName, string phoneNumber, string address, bool sex, DateTime dOB, double salary)
        {
            EmployeeId = EmployeesViewModel.NextId++;
            AgencyId = agencyId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            Address = address;
            Sex = sex;
            DOB = dOB;
            Salary = salary;
        }
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

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
