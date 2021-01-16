using HQTCSDL.TeamProject.RealEstateAgency.View.ChiNhanhScreens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.AgencyView.ContentControls
{
    public class HomeScreenViewModel : BaseViewModel
    {
        private static HomeScreenViewModel instance;

        public static HomeScreenViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HomeScreenViewModel();
                }
                return instance;
            }
        }
        public int MACN = 1;
        public ObservableCollection<NHANVIEN> Staffs { get; set; }
        public NHANVIEN SelectedStaff { get; set; }

        public ObservableCollection<NHA> Houses { get; set; }
        public ObservableCollection<NHA> AllHouses { get; set; }
        public ObservableCollection<LOAINHA> AllHouseTypes { get; set; }
        public ObservableCollection<CHUNHA> AllHouseOwners { get; set; }

        public NHA SelectedHouse { get; set; }
        public CHITIETNHATHUE SelectedHouseForRent { get; set; }
        public CHITIETNHABAN SelectedHouseForSale { get; set; }

        public int HouseType { get; set; }

        public ObservableCollection<KHACHHANG> Customers { get; set; }
        public KHACHHANG SelectedCustomer { get; set; }

        public Dictionary<int, int> OldNewHousetypeRequest { get; set; }

        private HomeScreenViewModel()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Houses = new ObservableCollection<NHA>(db.NHAs.Where(item => item.MACN == MACN));
                AllHouses = new ObservableCollection<NHA>(db.NHAs.Where(item => item.MACN == MACN));
                AllHouseTypes = new ObservableCollection<LOAINHA>(db.LOAINHAs);
                AllHouseOwners = new ObservableCollection<CHUNHA>(db.CHUNHAs);

                Staffs = new ObservableCollection<NHANVIEN>(db.NHANVIENs.Where(item => item.MACN == MACN));

                Customers = new ObservableCollection<KHACHHANG>(db.KHACHHANGs.Where(item => item.CNQUANLY == MACN));

            }
            SelectedHouse = new NHA();
            SelectedHouseForRent = new CHITIETNHATHUE();
            SelectedHouseForSale = new CHITIETNHABAN();

            SelectedStaff = new NHANVIEN();

            SelectedCustomer = new KHACHHANG();
            OldNewHousetypeRequest = new Dictionary<int, int>();
        }

        internal void UpdateHousePriceIfYes(int soLuong, float phanTram)
        {
            QUANLYNHADATEntities db = new QUANLYNHADATEntities();
            var dataContext = db.USP_IsPriceIncreases(phanTram, soLuong, MACN);
            var screen = new Agency_IsHousePriceIncreases("Thông kê nhà tăng giá")
            {
                DataContext = dataContext
            };
            screen.Show();
        }

        internal void GetHouseSuitable(int maLoai)
        {
            QUANLYNHADATEntities db = new QUANLYNHADATEntities();
            var dataContext = db.USP_GetCustomerSuitableHouse(maLoai, MACN);
            var screen = new Agency_IsHousePriceIncreases("Các nhà phù hợp yêu cầu")
            {
                DataContext = dataContext
            };
            screen.Show();
        }

        internal void updateHousePriceInHouseRent()
        {
            try
            {
                int maNha = SelectedHouse.MANHA;
                int newPrice = (int)SelectedHouseForRent.GIATHUE;
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    db.USP_UpdateHousePrice(MACN, maNha, newPrice);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        internal void updateHouseTypeInHouse()
        {
            try
            {
                int maNha = SelectedHouse.MANHA;
                int newLoaiNha = SelectedHouse.LOAINHA.MALOAI;
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    db.USP_UpdateHouseTypeInHouse(maNha, newLoaiNha);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        internal void UpdateStaffSalary()
        {
            try
            {
                int maNV = SelectedStaff.MANV;
                int newLuong = (int)SelectedStaff.LUONG;
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    db.USP_UpdateSalaryStaff(maNV, newLuong);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        internal void UpdateOldNewHousetypeRequest()
        {
            try
            {
                int maKH = SelectedCustomer.MAKH;
                int oldType = OldNewHousetypeRequest.Keys.ToList()[0];
                int newType = OldNewHousetypeRequest[oldType];
                QUANLYNHADATEntities db = new QUANLYNHADATEntities();
                var datacontext = db.USP_UpdateCustomerDemand(maKH, newType, oldType, MACN);
                var screen = new Agency_IsHousePriceIncreases("Sau khi cập nhập thong tin khách hàng")
                {
                    DataContext = datacontext
                };
                screen.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        internal void SetSelectedHouse(NHA selectedNha)
        {
            SelectedHouse = selectedNha;
            if (selectedNha != null)
            {
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    SelectedHouseForRent = db.CHITIETNHATHUEs.FirstOrDefault(item => item.MANHA == selectedNha.MANHA);
                    SelectedHouseForSale = db.CHITIETNHABANs.FirstOrDefault(item => item.MANHA == selectedNha.MANHA);
                }
            }
            else
            {
                SelectedHouseForRent = new CHITIETNHATHUE();
                SelectedHouseForSale = new CHITIETNHABAN();
            }

            if (SelectedHouseForRent != null)
                HouseType = 0;
            else if (SelectedHouseForSale != null)
                HouseType = 1;
        }

        internal void GetAllStaffs()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Staffs = new ObservableCollection<NHANVIEN>(db.NHANVIENs.Where(item => item.MACN == MACN));
            }
        }

        internal void SetSelectedStaff(NHANVIEN seletedStaff)
        {
            SelectedStaff = seletedStaff;
        }

        internal void AddOldNewHouseRequest(int oldType, int newType)
        {
            OldNewHousetypeRequest.Add(oldType, newType);
        }

        internal void SetSelectedCustomer(KHACHHANG kHACHHANG)
        {

            if (kHACHHANG != null)
            {
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    SelectedCustomer = db.KHACHHANGs.FirstOrDefault(item => item.MAKH == kHACHHANG.MAKH);
                }
            }
            else
            {
                SelectedCustomer = kHACHHANG;
            }
        }

        internal void SetHouseRentOrSale(string text)
        {
            HouseType = int.Parse(text);

        }
    }
}
