namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_NHANH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CHI_NHANH()
        {
            STK_NGAN_HANG = new HashSet<STK_NGAN_HANG>();
            KHACH_HANG = new HashSet<KHACH_HANG>();
            NHAN_VIEN = new HashSet<NHAN_VIEN>();
        }

        [Key]
        [StringLength(50)]
        public string MaChiNhanh { get; set; }

        [StringLength(50)]
        public string TenChiNhanh { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }

        public int? ID_Huyen { get; set; }

        public int? ID_Tinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STK_NGAN_HANG> STK_NGAN_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHACH_HANG> KHACH_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NHAN_VIEN> NHAN_VIEN { get; set; }

        public virtual QUAN_HUYEN QUAN_HUYEN { get; set; }
    }
}
