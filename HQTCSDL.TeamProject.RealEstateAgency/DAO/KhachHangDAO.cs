using Force.DeepCloner;
using HQTCSDL.TeamProject.RealEstateAgency.Utils;
using System.Collections.ObjectModel;
using System.Windows;

namespace HQTCSDL.TeamProject.RealEstateAgency.DAO
{
    public sealed class KhachHangDAO
    {
        private static ObservableCollection<KHACHHANG> customersCollection = null;
        private static KhachHangDAO instance;
        private bool needReset;

        private KhachHangDAO()
        {
            instance = null;
            this.needReset = false;
        }
        private void Reset() => this.needReset = true;

        public static KhachHangDAO GetInstance() => instance ?? new KhachHangDAO();

        public ObservableCollection<KHACHHANG> GetAllCustomers()
        {
            if (customersCollection == null || this.needReset)
            {
                if (this.needReset)
                {
                    this.needReset = false;
                }
                using var db = new QUANLYNHADATEntities();
                //db.Configuration.LazyLoadingEnabled = false;
                customersCollection = db.KHACHHANGs.ToObservableCollection();
            }
            return customersCollection;
        }

        public KHACHHANG GetCustomerById(object[] keys)
        {
            var maKH = (int)keys[0];
            var cnQuanLy = (int)keys[1];

            using (var db = new QUANLYNHADATEntities())
            {
                var customer = db.KHACHHANGs.Find(maKH, cnQuanLy);
                if (customer != null)
                {
                    return customer.ShallowClone();
                }
            }
            return null;
        }

        public void AddNewCustomer(KHACHHANG KhachHang)
        {
            if (KhachHang is null)
            {
                throw new System.ArgumentNullException(nameof(KhachHang));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.KHACHHANGs.Add(KhachHang);
                db.SaveChanges();
            }

            this.Reset();
        }

        //Read for deadlock
        public void EditCustomer(KHACHHANG KhachHang)
        {
            if (KhachHang is null)
            {
                throw new System.ArgumentNullException(nameof(KhachHang));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                var customer = db.KHACHHANGs.Find(KhachHang.MAKH, KhachHang.CNQUANLY);
                if (customer != null)
                {
                    customer.CNQUANLY = KhachHang.CNQUANLY;
                    customer.SDT = KhachHang.SDT;
                    if (customer.TEN != KhachHang.TEN &&
                        customer.DIACHI != KhachHang.DIACHI &&
                        customer.CHITIET != KhachHang.CHITIET)
                    {
                        this.UpdateNameAndAddressAndDetail(KhachHang);
                    }
                    /*customer.TEN = KhachHang.TEN;
                    customer.DIACHI = KhachHang.DIACHI;
                    customer.CHITIET = KhachHang.CHITIET;*/
                    db.SaveChanges();
                }
            }
            this.Reset();
        }

        public void DeleteCustomer(KHACHHANG KhachHang)
        {
            if (KhachHang is null)
            {
                throw new System.ArgumentNullException(nameof(KhachHang));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                db.KHACHHANGs.Remove(KhachHang);
                db.SaveChanges();
            }

            this.Reset();
        }

        private void UpdateNameAndAddressAndDetail(KHACHHANG KhachHang)
        {
            if (KhachHang is null)
            {
                throw new System.ArgumentNullException(nameof(KhachHang));
            }

            using (var db = new QUANLYNHADATEntities())
            {
                try
                {
                    db.USP_UpdateCustomerDetail(KhachHang.MAKH, KhachHang.CNQUANLY, KhachHang.TEN, KhachHang.DIACHI, KhachHang.CHITIET);
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
