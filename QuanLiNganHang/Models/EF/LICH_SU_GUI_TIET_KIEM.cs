namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LICH_SU_GUI_TIET_KIEM
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string STK { get; set; }

        public int? IDLaiSuat { get; set; }

        public long? SoTien { get; set; }

        public DateTime? NgayGui { get; set; }

        public virtual LAI_SUAT LAI_SUAT { get; set; }

        public virtual STK STK1 { get; set; }
    }
}
