using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public sealed class UsersList
    {
        private static ObservableCollection<User> Users { get; }

        static UsersList()
        {
            Users = new ObservableCollection<User>
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

        internal static string GetUserRole(string username, string password)
        {
            if (IsContainUser(username, password))
            {
                var user = GetCorrespondingUser(username, password);
                return user.GetRole();
            }
            return null;
        }

        private static User GetCorrespondingUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.IsExist(username, password))
                {
                    return user;
                }
            }
            return null;
        }

        public static bool IsContainUser(string username, string password)
        {
            var result = false;

            foreach (var user in Users)
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