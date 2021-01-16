using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class LoaiNhaDAO
    {
        private static ObservableCollection<LOAINHA> houseCategoriesCollection = null;
        private static LoaiNhaDAO instance;
        private bool needReset;

        private LoaiNhaDAO()
        {
            instance = null;
            this.needReset = false;
        }

        private void Reset() => this.needReset = true;

        public static LoaiNhaDAO GetInstance() => instance ?? new LoaiNhaDAO();

        public ObservableCollection<LOAINHA> GetAllHouseCategories()
        {
            if (houseCategoriesCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                houseCategoriesCollection = db.LOAINHAs.ToObservableCollection();
            }
            return houseCategoriesCollection;
        }

        public LOAINHA GetHouseCategoryById(int id)
        {
            if (id > 0)
            {
                using (var db = new QUANLYNHADATEntities())
                {
                    var houseCate = db.LOAINHAs.Find(id);
                    if (houseCate != null)
                    {
                        return houseCate.ShallowClone();
                    }
                }
            }
            return null;
        }

        public void AddNewHouseCategory(LOAINHA loaiNha)
        {
            if (loaiNha is null)
            {
                throw new System.ArgumentNullException(nameof(loaiNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.LOAINHAs.Add(loaiNha);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditHouseCategory(LOAINHA loaiNha)
        {
            if (loaiNha is null)
            {
                throw new System.ArgumentNullException(nameof(loaiNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var houseCate = db.LOAINHAs.Find(loaiNha.MALOAI);
                if (houseCate != null)
                {
                    houseCate.TEN = loaiNha.TEN;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteHouseCategory(LOAINHA loaiNha)
        {
            if (loaiNha is null)
            {
                throw new System.ArgumentNullException(nameof(loaiNha));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.LOAINHAs.Remove(loaiNha);
                db.SaveChanges();
            }

            this.Reset();
        }
    }
}
