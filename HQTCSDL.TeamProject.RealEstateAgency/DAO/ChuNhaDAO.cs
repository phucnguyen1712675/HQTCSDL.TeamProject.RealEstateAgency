using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateHouseOwner.DAO
{
    public sealed class ChuNhaDAO
    {
        private static ObservableCollection<CHUNHA> houseOwnersCollection = null;
        private static ChuNhaDAO instance;
        private bool needReset;

        private ChuNhaDAO()
        {
            instance = null;
            this.needReset = false;
        }
        private void Reset() => this.needReset = true;

        public static ChuNhaDAO GetInstance() => instance ?? new ChuNhaDAO();

        public ObservableCollection<CHUNHA> GetAllHousOwners()
        {
            if (houseOwnersCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                houseOwnersCollection = db.CHUNHAs.ToObservableCollection();
            }
            return houseOwnersCollection;
        }

        public CHUNHA GetHouseOwnerById(int id)
        {
            if (id > 0)
            {
                using (var db = new QUANLYNHADATEntities())
                {
                    var HouseOwner = db.CHUNHAs.Find(id);
                    if (HouseOwner != null)
                    {
                        return HouseOwner.ShallowClone();
                    }
                }
            }
            return null;
        }

        public void AddNewHouseOwner(CHUNHA ChuNha)
        {
            if (ChuNha is null)
            {
                throw new System.ArgumentNullException(nameof(ChuNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHUNHAs.Add(ChuNha);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditHouseOwner(CHUNHA ChuNha)
        {
            if (ChuNha is null)
            {
                throw new System.ArgumentNullException(nameof(ChuNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var HouseOwner = db.CHUNHAs.Find(ChuNha.MACNHA);
                if (HouseOwner != null)
                {
                    HouseOwner.TEN = ChuNha.TEN;
                    HouseOwner.SDT = ChuNha.SDT;
                    HouseOwner.DIACHI = ChuNha.DIACHI;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteHouseOwner(CHUNHA ChuNha)
        {
            if (ChuNha is null)
            {
                throw new System.ArgumentNullException(nameof(ChuNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHUNHAs.Remove(ChuNha);
                db.SaveChanges();
            }

            this.Reset();
        }
    }
}
