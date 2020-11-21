﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    class AddNewEmployeeDialogViewModel : INotifyPropertyChanged
    {
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int AgencyId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool Sex { get; set; } //true - Nam || false - Nu
        public DateTime DOB { get; set; }
        public double Salary { get; set; }
        public ObservableCollection<int> HasEmployeesAgencyList { get; set; }
        public AddNewEmployeeDialogViewModel()
        {
            var viewModel = new EmployeesViewModel();
            HasEmployeesAgencyList = new ObservableCollection<int>(viewModel.HasEmployeesAgencyList);
        }
    }
}
