using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class ChiNhanhDAO
    {
        private static ObservableCollection<CHINHANH> agenciesCollection = null;
        private static ChiNhanhDAO instance;
        private bool needReset;

        private ChiNhanhDAO()
        {
            instance = null;
            this.needReset = false;
        }
        private void Reset() => this.needReset = true;

        public static ChiNhanhDAO GetInstance() => instance ?? new ChiNhanhDAO();

        public ObservableCollection<CHINHANH> GetAllAgencies()
        {
            if (agenciesCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                agenciesCollection = db.CHINHANHs.ToObservableCollection();
            }
            return agenciesCollection;
        }

        public CHINHANH GetAgencyById(int id)
        {
            if (id > 0)
            {
                using (var db = new QUANLYNHADATEntities())
                {
                    var agency = db.CHINHANHs.Find(id);
                    if (agency != null)
                    {
                        return agency.ShallowClone();
                    }
                }
            }
            return null;
        }

        public void AddNewAgency(CHINHANH chiNhanh)
        {
            if (chiNhanh is null)
            {
                throw new System.ArgumentNullException(nameof(chiNhanh));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHINHANHs.Add(chiNhanh);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditAgency(CHINHANH chiNhanh)
        {
            if (chiNhanh is null)
            {
                throw new System.ArgumentNullException(nameof(chiNhanh));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var agency = db.CHINHANHs.Find(chiNhanh.MACN);
                if (agency != null)
                {
                    agency.FAX = chiNhanh.FAX;
                    agency.SDT = chiNhanh.SDT;
                    agency.DIACHI = chiNhanh.DIACHI;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteAgency(CHINHANH chiNhanh)
        {
            if (chiNhanh is null)
            {
                throw new System.ArgumentNullException(nameof(chiNhanh));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.CHINHANHs.Remove(chiNhanh);
                db.SaveChanges();
            }

            this.Reset();
        }
    }
}
