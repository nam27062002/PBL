namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LICH_SU_MO_KHOA_THE
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string STK { get; set; }

        public DateTime? NgayKhoaThe { get; set; }

        public DateTime? NgayMoThe { get; set; }

        [StringLength(50)]
        public string LiDoKhoaThe { get; set; }

        public virtual STK STK1 { get; set; }
    }
}
