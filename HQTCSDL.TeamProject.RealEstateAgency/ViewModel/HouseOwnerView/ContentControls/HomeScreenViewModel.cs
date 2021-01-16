using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.ViewModel.HouseOwnerView.ContentControls
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

        public int MACNHA = 1;
        public int MACN = 1;

        public ObservableCollection<NHA> Houses { get; set; }

        public NHA SelectedHouse { get; set; }

        public CHITIETNHATHUE SelectedHouseForRent { get; set; }
        public CHITIETNHABAN SelectedHouseForSale { get; set; }

        public int HouseType { get; set; }

        public ObservableCollection<LOAINHA> AllHouseTypes { get; set; }


        private HomeScreenViewModel()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Houses = new ObservableCollection<NHA>(db.NHAs.Where(item => item.MACNHA == MACNHA).ToList());
                AllHouseTypes = new ObservableCollection<LOAINHA>(db.LOAINHAs);
            }
            SelectedHouse = new NHA();
            SelectedHouseForRent = new CHITIETNHATHUE();
            SelectedHouseForSale = new CHITIETNHABAN();
        }

        internal void UpdateStateHouse()
        {
            int Houseid = SelectedHouse.MANHA;
            DateTime OutofDate = (DateTime)SelectedHouse.NGAYHETHAN;
            DateTime Date = DateTime.Now;
            string State = SelectedHouse.TINHTRANG;
            try
            {
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    db.USP_TEST_AGENCY_UpdateHouseInformation(Houseid, OutofDate, Date, State);
                }
            }
            catch (Exception ex) {}
        }

        internal void updateHouseHouseType(int maNha, int newLoaiNha)
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                db.USP_UpdateHouseInHouseType_Test(maNha, newLoaiNha);
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
                SelectedHouse = new NHA();
            }

            if (SelectedHouseForRent != null)
                HouseType = 0;
            else if (SelectedHouseForSale != null)
                HouseType = 1;
        }

        internal void DeleteHouse(int maNha)
        {
            try
            {
                using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
                {
                    db.USP_USER_DeleteHouse(maNha);
                }
            }
            catch (Exception ex) { }
        }

        internal void AddNewHouseForRent()
        {
            //int MANV = 1;
            int MALOAI = (int)SelectedHouse.LOAINHA.MALOAI;
            int SLPO = (int)SelectedHouse.SOLUONGPHONGO;
            string Duong = SelectedHouse.DUONG;
            string Quan = SelectedHouse.QUAN;
            string KhuVuc = SelectedHouse.KHUVUC;
            string ThanhPho = SelectedHouse.THANHPHO;
            string TinhTrang = HouseType.ToString();
            int GiaThue = (int)SelectedHouseForRent.GIATHUE;
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                db.USP_AddHouseForRent(MACN, MACNHA, 1, MALOAI, SLPO, null, null, Duong, Quan, KhuVuc, ThanhPho, TinhTrang, null, GiaThue);
            }
        }

        internal void GetAllHouseAgain()
        {
            using (QUANLYNHADATEntities db = new QUANLYNHADATEntities())
            {
                Houses = new ObservableCollection<NHA>(db.NHAs.Where(item => item.MACNHA == MACNHA).ToList());
                foreach (var house in Houses)
                    house.LOAINHA = db.LOAINHAs.FirstOrDefault(item => item.MALOAI == house.MALOAI);
                AllHouseTypes = new ObservableCollection<LOAINHA>(db.LOAINHAs);
            }
        }

        internal void SetHouseRentOrSale(string text)
        {
            HouseType = int.Parse(text);
        }
    }
}
