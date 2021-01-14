using PropertyChanged;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    [AddINotifyPropertyChangedInterface]
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }

        internal bool IsExist(string username, string password) => this.UserName.Equals(username) && this.Password.Equals(password);

        public string GetRole()
            => this.Role;
    }
}
