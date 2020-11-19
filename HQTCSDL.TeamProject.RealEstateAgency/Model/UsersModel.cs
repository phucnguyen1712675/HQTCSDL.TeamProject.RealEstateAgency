using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class UsersModel : INotifyPropertyChanged
    {
        public UsersModel(string userName, string password, bool status, string role)
        {
            UserId = UsersViewModel.NextId++;
            UserName = userName;
            Password = password;
            Status = status;
            Role = role;
        }
#pragma warning disable 67
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 67

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }

        internal bool IsExist(string username, string password)
        {
            return this.UserName.Equals(username) && this.Password.Equals(password);
        }

        public string Role { get; set; }
    }
}
