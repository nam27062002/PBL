namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LICH_SU_DANG_NHAP
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string SDT { get; set; }

        public DateTime? NgayDangNhap { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
