namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LICH_SU_NGAN_HANG_CHUYEN_TIEN
    {
        [Key]
        [StringLength(50)]
        public string MaGiaoDich { get; set; }

        [StringLength(50)]
        public string STKChuyen { get; set; }

        [StringLength(50)]
        public string STKNhan { get; set; }

        public long? SoTien { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        public DateTime? NgayChuyen { get; set; }

        public virtual STK_NGAN_HANG STK_NGAN_HANG { get; set; }

        public virtual STK STK { get; set; }
    }
}
