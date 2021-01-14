using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.StaffView;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public class UserMainWindowDictinary
    {
        private Dictionary<string, BaseMainWindowViewModel> _mainWindowList;

        public UserMainWindowDictinary()
        {
            GetMainWindowList();
        }
        private void GetMainWindowList()
        {
            this._mainWindowList = new Dictionary<string, BaseMainWindowViewModel>
            {
                { "Company", new CompanyMainWindowViewModel() },
                { "Agency", new AgencyMainWindowViewModel() },
                { "Staff", new StaffMainWindowViewModel() },
                { "House owner", new HouseOwnerMainWindowViewModel() }
            };
        }
        internal BaseMainWindowViewModel GetCorrespondingMainWindowViewModel(string role)
        {
            if (this._mainWindowList.ContainsKey(role))
            {
                return this._mainWindowList[role];
            }
            return null;
        }
    }
}
