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
    using PropertyChanged;
    using System;

    [AddINotifyPropertyChangedInterface]

    public partial class CHITIETNHABAN
    {
        public int MANHA { get; set; }
        public int MACN { get; set; }
        public Nullable<int> GIABAN { get; set; }
        public string DIEUKIEN { get; set; }

        public virtual NHA NHA { get; set; }
    }
}
