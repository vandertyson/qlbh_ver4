//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService3
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_QUYEN_CHI_TIET
    {
        public decimal ID { get; set; }
        public decimal ID_TAI_KHOAN { get; set; }
        public decimal ID_CUA_HANG { get; set; }
        public decimal ID_QUYEN { get; set; }
    
        public virtual DM_CUA_HANG DM_CUA_HANG { get; set; }
        public virtual DM_QUYEN DM_QUYEN { get; set; }
        public virtual DM_TAI_KHOAN DM_TAI_KHOAN { get; set; }
    }
}
