//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppBanVeRapPhim.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChiTietHoaDon
    {
        public int Ma { get; set; }
        public int MaHoaDon { get; set; }
        public string ViTriGheNgoi { get; set; }
        public Nullable<decimal> GiaTien { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
    }
}
