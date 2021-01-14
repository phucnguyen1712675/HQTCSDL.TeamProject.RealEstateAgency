using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class UsersList
    {
        private ObservableCollection<User> Users { get; set; }
        
        public UsersList()
        {
            GetUserCollection();
        }

        private void GetUserCollection()
        {
            this.Users = new ObservableCollection<User>
            {
                new User
                {
                    UserName = "admin",
                    Password = "admin",
                    Status = true,
                    Role = "Company"
                },
                new User
                {
                    UserName = "chinhanh",
                    Password = "chinhanh",
                    Status = true,
                    Role = "Agency"
                },
                new User
                {
                    UserName = "nhanvien",
                    Password = "nhanvien",
                    Status = true,
                    Role = "Staff"
                },
                new User
                {
                    UserName = "chunha",
                    Password = "chunha",
                    Status = true,
                    Role = "House owner"
                }
            };
        }

        internal string GetUserRole(string username, string password)
        {
            if (IsContainUser(username, password))
            {
                var user = GetCorrespondingUser(username, password);
                return user.GetRole();
            }
            return null;
        }

        private User GetCorrespondingUser(string username, string password)
        {
            foreach (var user in this.Users)
            {
                if (user.IsExist(username, password))
                {
                    return user;
                }
            }
            return null;
        }

        public bool IsContainUser(string username, string password)
        {
            var result = false;

            foreach (var user in this.Users)
            {
                if (user.IsExist(username, password))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
    }
}
