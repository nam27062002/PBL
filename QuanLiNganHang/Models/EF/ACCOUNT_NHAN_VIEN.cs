namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ACCOUNT_NHAN_VIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT_NHAN_VIEN()
        {
            LICH_SU_NHAN_VIEN_DANG_NHAP = new HashSet<LICH_SU_NHAN_VIEN_DANG_NHAP>();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Pass { get; set; }

        public virtual NHAN_VIEN NHAN_VIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_NHAN_VIEN_DANG_NHAP> LICH_SU_NHAN_VIEN_DANG_NHAP { get; set; }
    }
}
