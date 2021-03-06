﻿using HQTCSDL.TeamProject.RealEstateAgency.ViewModel;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.Company;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView;
using HQTCSDL.TeamProject.RealEstateAgency.ViewModel.StaffView;
using System.Collections.Generic;

namespace HQTCSDL.TeamProject.RealEstateAgency.Model
{
    public sealed class UserMainWindowDictinary
    {
        private readonly Dictionary<string, BaseMainWindowViewModel> _mainWindowList;
        private static UserMainWindowDictinary instance;

        private UserMainWindowDictinary()
        {
            instance = null;

            this._mainWindowList = new Dictionary<string, BaseMainWindowViewModel>
            {
                { "Company", new CompanyMainWindowViewModel() },
                { "Agency", new AgencyMainWindowViewModel() },
                { "Staff", new StaffMainWindowViewModel() },
                { "House owner", new HouseOwnerMainWindowViewModel() }
            };
        }

        public static UserMainWindowDictinary GetInstance() => instance ?? new UserMainWindowDictinary();

        public BaseMainWindowViewModel GetCorrespondingMainWindowViewModel(string role)
        {
            if (this._mainWindowList.ContainsKey(role))
            {
                return this._mainWindowList[role];
            }
            return null;
        }
    }
}