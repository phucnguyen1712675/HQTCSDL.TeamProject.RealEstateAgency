//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HQTCSDL.TeamProject.RealEstateAgency
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class NHA
    {
        public int MANHA { get; set; }
        public int MACN { get; set; }
        public Nullable<int> MACNHA { get; set; }
        public Nullable<int> MANV { get; set; }
        public Nullable<int> MALOAI { get; set; }
        public Nullable<int> SOLUONGPHONGO { get; set; }
        public Nullable<System.DateTime> NGAYHETHAN { get; set; }
        public Nullable<System.DateTime> NGAYDANG { get; set; }
        public string DUONG { get; set; }
        public string QUAN { get; set; }
        public string KHUVUC { get; set; }
        public string THANHPHO { get; set; }
        public string TINHTRANG { get; set; }
        public Nullable<int> SOLUOTXEM { get; set; }
    
        public virtual CHITIETNHABAN CHITIETNHABAN { get; set; }
        public virtual CHITIETNHATHUE CHITIETNHATHUE { get; set; }
        public virtual CHUNHA CHUNHA { get; set; }
        public virtual LOAINHA LOAINHA { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
