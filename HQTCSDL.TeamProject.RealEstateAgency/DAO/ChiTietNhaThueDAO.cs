using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class ChiTietNhaThueDAO
    {
        private static ObservableCollection<CHITIETNHATHUE> rentalHousingDetailsCollection = null;
        private static ChiTietNhaThueDAO instance;
        private bool needReset;

        private ChiTietNhaThueDAO()
        {
            instance = null;
            this.needReset = false;
        }
        private void Reset() => this.needReset = true;

        public static ChiTietNhaThueDAO GetInstance() => instance ?? new ChiTietNhaThueDAO();

        public ObservableCollection<CHITIETNHATHUE> GetAllRentalHousingDetails()
        {
            if (rentalHousingDetailsCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                rentalHousingDetailsCollection = db.CHITIETNHATHUEs.ToObservableCollection();
            }
            return rentalHousingDetailsCollection;
        }

        public CHITIETNHATHUE GetRentalhouseDetailById(object[] keys)
        {
            var maNha = (int)keys[0];
            var maCN = (int)keys[1];

            using (var db = new QUANLYNHADATEntities())
            {
                var rentalhouseDetail = db.CHITIETNHATHUEs.Find(maNha, maCN);
                if (rentalhouseDetail != null)
                {
                    return rentalhouseDetail.ShallowClone();
                }
            }
            return null;
        }

        public void AddNewRentalhouseDetail(CHITIETNHATHUE ChiTietNhaThue)
        {
            if (ChiTietNhaThue is null)
            {
                throw new System.ArgumentNullException(nameof(ChiTietNhaThue));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHITIETNHATHUEs.Add(ChiTietNhaThue);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditRentalhouseDetail(CHITIETNHATHUE ChiTietNhaThue)
        {
            if (ChiTietNhaThue is null)
            {
                throw new System.ArgumentNullException(nameof(ChiTietNhaThue));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var rentalhouseDetail = db.CHITIETNHATHUEs.Find(ChiTietNhaThue.MANHA, ChiTietNhaThue.MACN);
                if (rentalhouseDetail != null)
                {
                    rentalhouseDetail.MACN = ChiTietNhaThue.MACN;
                    if (rentalhouseDetail.GIATHUE != ChiTietNhaThue.GIATHUE)
                    {
                        UpdateHouseRentalPrice(ChiTietNhaThue);
                    }
                    //rentalhouseDetail.GIATHUE = ChiTietNhaThue.GIATHUE;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteRentalhouseDetail(CHITIETNHATHUE ChiTietNhaThue)
        {
            if (ChiTietNhaThue is null)
            {
                throw new System.ArgumentNullException(nameof(ChiTietNhaThue));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHITIETNHATHUEs.Remove(ChiTietNhaThue);
                db.SaveChanges();
            }

            this.Reset();
        }

        public bool IsContainsHouse(NHA Nha)
        {
            if (Nha is null)
            {
                throw new System.ArgumentNullException(nameof(Nha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                return db.CHITIETNHATHUEs.Any(c => c.MANHA == Nha.MANHA && c.MACN == Nha.MACN);
            }
        }

        private void UpdateHouseRentalPrice(CHITIETNHATHUE ChiTietNhaThue)
        {
            if (ChiTietNhaThue is null)
            {
                throw new System.ArgumentNullException(nameof(ChiTietNhaThue));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                try
                {
                    db.USP_UpdateHousePrice(ChiTietNhaThue.MACN, ChiTietNhaThue.MANHA, ChiTietNhaThue.GIATHUE);
                    db.SaveChanges();
                    this.Reset();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        public void UpdateHouseRentalPrice(object[] keys)
        {
            var maNha = (int)keys[0];
            var maCN = (int)keys[1];
            var price = (int?)keys[2];

            using (var db = new QUANLYNHADATEntities())
            {
                var rentalhouseDetail = db.CHITIETNHATHUEs.Find(maNha, maCN);
                if (rentalhouseDetail != null)
                {
                    try
                    {
                        db.USP_UpdateHousePrice(maCN, maNha, price);
                        db.SaveChanges();
                        this.Reset();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
