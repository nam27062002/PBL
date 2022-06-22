namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STK_NGAN_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STK_NGAN_HANG()
        {
            LICH_SU_NGAN_HANG_CHUYEN_TIEN = new HashSet<LICH_SU_NGAN_HANG_CHUYEN_TIEN>();
            LICH_SU_NGAN_HANG_NHAN_TIEN = new HashSet<LICH_SU_NGAN_HANG_NHAN_TIEN>();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [Key]
        [StringLength(50)]
        public string STK { get; set; }

        public long? SoDu { get; set; }

        public long? TienMat { get; set; }

        public DateTime? NgayMoTK { get; set; }

        public bool? TrangThai { get; set; }

        public virtual CHI_NHANH CHI_NHANH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_NGAN_HANG_CHUYEN_TIEN> LICH_SU_NGAN_HANG_CHUYEN_TIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_NGAN_HANG_NHAN_TIEN> LICH_SU_NGAN_HANG_NHAN_TIEN { get; set; }
    }
}
