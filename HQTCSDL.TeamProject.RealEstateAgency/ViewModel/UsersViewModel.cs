using HQTCSDL.TeamProject.RealEstateAgency.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel
{
    public class UsersViewModel
    {
        public static int NextId = 1;
        public ObservableCollection<UsersModel> UsersList { get; set; } = 
            new ObservableCollection<UsersModel>()
        {
                new UsersModel("admin", "admin", true, "Công ty"),
                new UsersModel("chinhanh", "chinhanh", true, "Chi nhánh"),
                new UsersModel("nhanvien", "nhanvien", true, "Nhân viên")
        };

        public bool ContainUser(string username, string password)
        {
            foreach (var user in UsersList)
            {
                if (user.IsExist(username, password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
