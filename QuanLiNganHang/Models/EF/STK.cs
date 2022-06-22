namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STK")]
    public partial class STK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STK()
        {
            LICH_SU_GUI_TIET_KIEM = new HashSet<LICH_SU_GUI_TIET_KIEM>();
            LICH_SU_KHACH_HANG_GIAO_DICH = new HashSet<LICH_SU_KHACH_HANG_GIAO_DICH>();
            LICH_SU_KHACH_HANG_GIAO_DICH1 = new HashSet<LICH_SU_KHACH_HANG_GIAO_DICH>();
            LICH_SU_MO_KHOA_THE = new HashSet<LICH_SU_MO_KHOA_THE>();
            LICH_SU_NGAN_HANG_CHUYEN_TIEN = new HashSet<LICH_SU_NGAN_HANG_CHUYEN_TIEN>();
            LICH_SU_NGAN_HANG_NHAN_TIEN = new HashSet<LICH_SU_NGAN_HANG_NHAN_TIEN>();
        }

        [Key]
        [Column("STK")]
        [StringLength(50)]
        public string STK1 { get; set; }

        public long? SoDu { get; set; }

        public DateTime? NgayCap { get; set; }

        [StringLength(50)]
        public string ID { get; set; }

        public bool? TrangThai { get; set; }

        public bool? Main { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_GUI_TIET_KIEM> LICH_SU_GUI_TIET_KIEM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_KHACH_HANG_GIAO_DICH> LICH_SU_KHACH_HANG_GIAO_DICH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_KHACH_HANG_GIAO_DICH> LICH_SU_KHACH_HANG_GIAO_DICH1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_MO_KHOA_THE> LICH_SU_MO_KHOA_THE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_NGAN_HANG_CHUYEN_TIEN> LICH_SU_NGAN_HANG_CHUYEN_TIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LICH_SU_NGAN_HANG_NHAN_TIEN> LICH_SU_NGAN_HANG_NHAN_TIEN { get; set; }
    }
}
