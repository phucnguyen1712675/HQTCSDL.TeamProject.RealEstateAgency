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
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.KEHOACHXEMNHAs = new ObservableCollection<KEHOACHXEMNHA>();
            this.NHAs = new ObservableCollection<NHA>();
        }
    
        public int MACN { get; set; }
        public int MANV { get; set; }
        public string TEN { get; set; }
        public string SDT { get; set; }
        public string DIACHI { get; set; }
        public Nullable<bool> GIOITINH { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<decimal> LUONG { get; set; }
    
        public virtual CHINHANH CHINHANH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<KEHOACHXEMNHA> KEHOACHXEMNHAs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<NHA> NHAs { get; set; }
    }
}
