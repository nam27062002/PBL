namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LICH_SU_NHAN_VIEN_DANG_NHAP
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string ID_NV { get; set; }

        public DateTime? NgayDangNhap { get; set; }

        public virtual ACCOUNT_NHAN_VIEN ACCOUNT_NHAN_VIEN { get; set; }
    }
}
