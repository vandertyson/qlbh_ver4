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
    
    public partial class DM_HANG_HOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_HANG_HOA()
        {
            this.DM_LINK_ANH = new HashSet<DM_LINK_ANH>();
            this.GD_CLICK_HANG_HOA = new HashSet<GD_CLICK_HANG_HOA>();
            this.GD_DANH_GIA = new HashSet<GD_DANH_GIA>();
            this.GD_GIA = new HashSet<GD_GIA>();
            this.GD_PHIEU_NHAP_CHI_TIET = new HashSet<GD_PHIEU_NHAP_CHI_TIET>();
            this.GD_HANG_HOA_TAG = new HashSet<GD_HANG_HOA_TAG>();
            this.GD_HOA_DON_CHI_TIET = new HashSet<GD_HOA_DON_CHI_TIET>();
            this.GD_KHUYEN_MAI_CHI_TIET = new HashSet<GD_KHUYEN_MAI_CHI_TIET>();
            this.GD_NHAN_XET = new HashSet<GD_NHAN_XET>();
            this.GD_PHIEU_NHAP_XUAT_CHI_TIET = new HashSet<GD_PHIEU_NHAP_XUAT_CHI_TIET>();
            this.GD_SAN_PHAM_UA_THICH = new HashSet<GD_SAN_PHAM_UA_THICH>();
            this.GD_TON_KHO = new HashSet<GD_TON_KHO>();
        }
    
        public decimal ID { get; set; }
        public string MA_HANG_HOA { get; set; }
        public string MA_VACH { get; set; }
        public string TEN_HANG_HOA { get; set; }
        public Nullable<decimal> ID_NHA_CUNG_CAP { get; set; }
        public string MO_TA { get; set; }
        public string DA_XOA { get; set; }
        public string MA_TRA_CUU { get; set; }
    
        public virtual DM_NHA_CUNG_CAP DM_NHA_CUNG_CAP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DM_LINK_ANH> DM_LINK_ANH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_CLICK_HANG_HOA> GD_CLICK_HANG_HOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_DANH_GIA> GD_DANH_GIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_GIA> GD_GIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_PHIEU_NHAP_CHI_TIET> GD_PHIEU_NHAP_CHI_TIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_HANG_HOA_TAG> GD_HANG_HOA_TAG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_HOA_DON_CHI_TIET> GD_HOA_DON_CHI_TIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_KHUYEN_MAI_CHI_TIET> GD_KHUYEN_MAI_CHI_TIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_NHAN_XET> GD_NHAN_XET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_PHIEU_NHAP_XUAT_CHI_TIET> GD_PHIEU_NHAP_XUAT_CHI_TIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_SAN_PHAM_UA_THICH> GD_SAN_PHAM_UA_THICH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GD_TON_KHO> GD_TON_KHO { get; set; }
    }
}
