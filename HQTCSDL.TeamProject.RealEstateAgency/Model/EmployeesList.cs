using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class EmployeesList
    {
        private ObservableCollection<Employee> employeesCollection { get; set; }

        public EmployeesList()
        {
            CreateEmployeesCollection();
        }

        private void CreateEmployeesCollection()
        {
            this.employeesCollection = new ObservableCollection<Employee>();

            //Fake data
            for (int i = 0; i < 5; i++)
            {
                this.employeesCollection.Add(new Employee
                {
                    EmployeeId = i + 1,
                    AgencyId = 1,
                    FullName = "Nguyen Van A" + i.ToString(),
                    PhoneNumber = "0985897654",
                    Address = "HCMUS",
                    Sex = true,
                    DOB = DateTime.Now,
                    Salary = 5000000.0
                });
            }
            this.employeesCollection.Add(new Employee
            {
                EmployeeId = 5,
                AgencyId = 2,
                FullName = "Nguyen Van B",
                PhoneNumber = "0985897654",
                Address = "HCMUS",
                Sex = true,
                DOB = DateTime.Now,
                Salary = 5000000.0
            });
            this.employeesCollection.Add(new Employee
            {
                EmployeeId = 6,
                AgencyId = 3,
                FullName = "Nguyen Van C",
                PhoneNumber = "0985897654",
                Address = "HCMUS",
                Sex = true,
                DOB = DateTime.Now,
                Salary = 5000000.0
            });
            for (int i = 7; i < 10; i++)
            {
                this.employeesCollection.Add(new Employee
                {
                    EmployeeId = i + 1,
                    AgencyId = 4,
                    FullName = "Nguyen Van A" + i.ToString(),
                    PhoneNumber = "0985897654",
                    Address = "HCMUS",
                    Sex = true,
                    DOB = DateTime.Now,
                    Salary = 5000000.0
                });
            }
            this.employeesCollection.Add(new Employee
            {
                EmployeeId = 10,
                AgencyId = 5,
                FullName = "Nguyen Van A",
                PhoneNumber = "0985897654",
                Address = "HCMUS",
                Sex = true,
                DOB = DateTime.Now,
                Salary = 5000000.0
            });
        }

        public ObservableCollection<Employee> GetEmployeesList()
            => this.employeesCollection;
    }
}
