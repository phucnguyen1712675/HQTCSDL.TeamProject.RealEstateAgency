using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private HomeScreenViewModel()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Houses = new ObservableCollection<NHA>(db.NHAs);
                AllHouses = new ObservableCollection<NHA>(db.NHAs);
                AllHouseTypes = new ObservableCollection<LOAINHA>(db.LOAINHAs);
                AllHouseOwners = new ObservableCollection<CHUNHA>(db.CHUNHAs);

                Staffs = new ObservableCollection<NHANVIEN>(db.NHANVIENs);
            }
            SelectedHouse = new NHA();
            SelectedHouseForRent = new CHITIETNHATHUE();
            SelectedHouseForSale = new CHITIETNHABAN();

            SelectedStaff = new NHANVIEN();
        }

        public void GetHousesByIndex(int index)
        {
            if(index== 0)
            {
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    Houses = new ObservableCollection<NHA>(db.NHAs);
                }
            }
            else
            {
                index = index - 1;
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    Houses = new ObservableCollection<NHA>( db.NHAs.Where(item => string.Equals(item.TINHTRANG ,index.ToString())).ToList());
                }
            }
        }

        internal void SetSelectedHouse(NHA selectedNha)
        {
            SelectedHouse = selectedNha;
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                SelectedHouseForRent = db.CHITIETNHATHUEs.FirstOrDefault(item => item.MANHA == selectedNha.MANHA);
                SelectedHouseForSale = db.CHITIETNHABANs.FirstOrDefault(item => item.MANHA == selectedNha.MANHA);
            }
            if (SelectedHouseForRent == null)
                HouseType = 0;
            else if (SelectedHouseForSale == null)
                HouseType = 1;
        }

        internal void GetAllStaffs()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Staffs = new ObservableCollection<NHANVIEN>(db.NHANVIENs);
            }
        }

        internal void SetSelectedStaff(NHANVIEN seletedStaff)
        {
            SelectedStaff = seletedStaff;
        }
    }
}
