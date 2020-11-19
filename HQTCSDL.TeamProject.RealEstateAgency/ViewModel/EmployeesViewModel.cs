using HQTCSDL.TeamProject.RealEstateAgency.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class EmployeesViewModel
    {
        public static int NextId = 1;
        public ObservableCollection<EmployeesModel> EmployeesList { get; set; } =
            new ObservableCollection<EmployeesModel>()
        {
                new EmployeesModel(1, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(1, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(2, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(3, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(4, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0),
                new EmployeesModel(5, "Nguyen Van A", "0985897654", "HCMUS", true, DateTime.Now, 5000000.0)
        };
    }
}
