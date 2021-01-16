using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class NhanVienDAO
    {
        private static ObservableCollection<NHANVIEN> staffsCollection = null;
        private static NhanVienDAO instance;
        private bool needReset;

        private NhanVienDAO()
        {
            instance = null;
            this.needReset = false;
        }

        private void Reset() => this.needReset = true;

        public static NhanVienDAO GetInstance() => instance ?? new NhanVienDAO();

        public ObservableCollection<NHANVIEN> GetAllStaffs()
        {
            if (staffsCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                staffsCollection = db.NHANVIENs.ToObservableCollection();
            }
            return staffsCollection;
        }

        public NHANVIEN GetStaffById(object[] keys)
        {
            var maCN = (int)keys[0];
            var maNV = (int)keys[1];

            using (var db = new QUANLYNHADATEntities())
            {
                var staff = db.NHANVIENs.Find(maCN, maNV);
                if (staff != null)
                {
                    return staff.ShallowClone();
                }
            }
            return null;
        }

        public void AddNewStaff(NHANVIEN nhanVien)
        {
            if (nhanVien is null)
            {
                throw new System.ArgumentNullException(nameof(nhanVien));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.NHANVIENs.Add(nhanVien);
                db.SaveChanges();
            }

            this.Reset();
        }

        public void EditStaff(NHANVIEN nhanVien)
        {
            if (nhanVien is null)
            {
                throw new System.ArgumentNullException(nameof(nhanVien));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var staff = db.NHANVIENs.Find(nhanVien.MACN, nhanVien.MANV);
                if (staff != null)
                {
                    staff.MACN = nhanVien.MACN;
                    staff.TEN = nhanVien.TEN;
                    staff.SDT = nhanVien.SDT;
                    staff.DIACHI = nhanVien.DIACHI;
                    staff.GIOITINH = nhanVien.GIOITINH;
                    staff.NGAYSINH = nhanVien.NGAYSINH;
                    if (staff.LUONG != nhanVien.LUONG)
                    {
                        this.UpdateSalary(nhanVien);
                    }
                    //staff.LUONG = nhanVien.LUONG;
                    db.SaveChanges();
                }
            }

            this.Reset();
        }

        public void DeleteStaff(NHANVIEN nhanVien)
        {
            if (nhanVien is null)
            {
                throw new System.ArgumentNullException(nameof(nhanVien));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var agency = db.CHINHANHs.Find(nhanVien.MACN);
                agency.NHANVIENs.Remove(nhanVien);
                db.NHANVIENs.Remove(nhanVien);
                db.SaveChanges();
            }

            this.Reset();
        }

        private void UpdateSalary(NHANVIEN nhanVien)
        {
            if (nhanVien == null)
            {
                throw new System.ArgumentNullException(nameof(nhanVien));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                try
                {
                    db.USP_UpdateSalaryStaff(nhanVien.MANV, (double)((decimal)nhanVien.LUONG));
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
