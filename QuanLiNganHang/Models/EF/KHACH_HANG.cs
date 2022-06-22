namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHACH_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHACH_HANG()
        {
            STKs = new HashSet<STK>();
            LICH_SU_DANG_NHAP = new HashSet<LICH_SU_DANG_NHAP>();
        }

        [StringLength(50)]
        public string TenKhachHang { get; set; }

        [StringLength(50)]
        public string CMND { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        public int? ID_Huyen { get; set; }

        public int? ID_Tinh { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [StringLength(50)]
        public string SDT { get; set; }

        [StringLength(50)]
        public string MaCN { get; set; }

        public virtual ACCOUNT_KHACH_HANG ACCOUNT_KHACH_HANG { get; set; }

        public virtual CHI_NHANH CHI_NHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STK> STKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_DANG_NHAP> LICH_SU_DANG_NHAP { get; set; }

        public virtual QUAN_HUYEN QUAN_HUYEN { get; set; }
    }
}
