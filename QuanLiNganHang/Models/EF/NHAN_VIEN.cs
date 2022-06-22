namespace QuanLiNganHang.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NHAN_VIEN
    {
        [StringLength(50)]
        public string TenNhanVien { get; set; }

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

        [StringLength(50)]
        public string MaCN { get; set; }

        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string position { get; set; }

        public long? Salary { get; set; }

        public DateTime? NgayNhanViec { get; set; }

        public virtual ACCOUNT_NHAN_VIEN ACCOUNT_NHAN_VIEN { get; set; }

        public virtual CHI_NHANH CHI_NHANH { get; set; }

        public virtual QUAN_HUYEN QUAN_HUYEN { get; set; }
    }
}
