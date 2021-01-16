using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class NhaDAO
    {
        private static ObservableCollection<NHA> housesCollection = null;
        private static NhaDAO instance;
        private bool needReset;

        private NhaDAO()
        {
            instance = null;
            this.needReset = false;
        }
        private void Reset() => this.needReset = true;

        public static NhaDAO GetInstance() => instance ?? new NhaDAO();

        public ObservableCollection<NHA> GetAllHouses()
        {
            if (housesCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                housesCollection = db.NHAs.ToObservableCollection();
            }
            return housesCollection;
        }

        public NHA GetHouseById(object[] keys)
        {
            var maNha = (int)keys[0];
            var maCN = (int)keys[1];

            using (var db = new QUANLYNHADATEntities())
            {
                var house = db.NHAs.Find(maNha, maCN);
                if (house != null)
                {
                    return house.ShallowClone();
                }
            }
            return null;
        }

        public void AddNewHouse(NHA Nha)
        {
            if (Nha is null)
            {
                throw new System.ArgumentNullException(nameof(Nha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.NHAs.Add(Nha);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditHouse(NHA Nha)
        {
            if (Nha is null)
            {
                throw new System.ArgumentNullException(nameof(Nha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var house = db.NHAs.Find(Nha.MANHA, Nha.MACN);
                if (house != null)
                {
                    house.MACN = Nha.MACN;
                    house.MACNHA = Nha.MACNHA;
                    house.MANV = Nha.MANV;
                    //house.MALOAI = Nha.MALOAI;
                    if (house.MALOAI != Nha.MALOAI)
                    {
                        this.UpdateHouseCategory(Nha);
                    }
                    house.SOLUONGPHONGO = Nha.SOLUONGPHONGO;
                    house.NGAYHETHAN = Nha.NGAYHETHAN;
                    house.NGAYDANG = Nha.NGAYDANG;
                    house.DUONG = Nha.DUONG;
                    house.QUAN = Nha.QUAN;
                    house.KHUVUC = Nha.KHUVUC;
                    house.THANHPHO = Nha.THANHPHO;
                    house.TINHTRANG = Nha.TINHTRANG;
                    house.SOLUOTXEM = Nha.SOLUOTXEM;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteHouse(NHA Nha)
        {
            if (Nha is null)
            {
                throw new System.ArgumentNullException(nameof(Nha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.NHAs.Remove(Nha);
                db.SaveChanges();
            }

            this.Reset();
        }

        private void UpdateHouseCategory(NHA Nha)
        {
            if (Nha is null)
            {
                throw new System.ArgumentNullException(nameof(Nha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                try
                {
                    db.USP_UpdateHouseTypeInHouse(Nha.MANHA, Nha.MALOAI);
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
