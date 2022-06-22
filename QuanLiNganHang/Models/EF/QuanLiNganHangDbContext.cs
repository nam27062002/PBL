using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLiNganHang.Models.EF
{
    public partial class QuanLiNganHangDbContext : DbContext
    {
        private static QuanLiNganHangDbContext _Instance;
        public static QuanLiNganHangDbContext Instance
        {
            get { return _Instance ?? (_Instance = new QuanLiNganHangDbContext()); }
            set { }
        }
        public QuanLiNganHangDbContext()
            : base("name=Model17")
        {
        }

        public virtual DbSet<ACCOUNT_KHACH_HANG> ACCOUNT_KHACH_HANG { get; set; }
        public virtual DbSet<ACCOUNT_NHAN_VIEN> ACCOUNT_NHAN_VIEN { get; set; }
        public virtual DbSet<CHI_NHANH> CHI_NHANH { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LAI_SUAT> LAI_SUAT { get; set; }
        public virtual DbSet<LICH_SU_DANG_NHAP> LICH_SU_DANG_NHAP { get; set; }
        public virtual DbSet<LICH_SU_GUI_TIET_KIEM> LICH_SU_GUI_TIET_KIEM { get; set; }
        public virtual DbSet<LICH_SU_KHACH_HANG_GIAO_DICH> LICH_SU_KHACH_HANG_GIAO_DICH { get; set; }
        public virtual DbSet<LICH_SU_MO_KHOA_THE> LICH_SU_MO_KHOA_THE { get; set; }
        public virtual DbSet<LICH_SU_NGAN_HANG_CHUYEN_TIEN> LICH_SU_NGAN_HANG_CHUYEN_TIEN { get; set; }
        public virtual DbSet<LICH_SU_NGAN_HANG_NHAN_TIEN> LICH_SU_NGAN_HANG_NHAN_TIEN { get; set; }
        public virtual DbSet<LICH_SU_NHAN_VIEN_DANG_NHAP> LICH_SU_NHAN_VIEN_DANG_NHAP { get; set; }
        public virtual DbSet<NHAN_VIEN> NHAN_VIEN { get; set; }
        public virtual DbSet<QUAN_HUYEN> QUAN_HUYEN { get; set; }
        public virtual DbSet<STK> STKs { get; set; }
        public virtual DbSet<STK_NGAN_HANG> STK_NGAN_HANG { get; set; }
        public virtual DbSet<TINH_THANH> TINH_THANH { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ACCOUNT_KHACH_HANG>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_KHACH_HANG>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_KHACH_HANG>()
                .Property(e => e.MaPin)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_NHAN_VIEN>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_NHAN_VIEN>()
                .Property(e => e.UserName)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_NHAN_VIEN>()
                .Property(e => e.Pass)
                .IsFixedLength();

            modelBuilder.Entity<ACCOUNT_NHAN_VIEN>()
                .HasMany(e => e.LICH_SU_NHAN_VIEN_DANG_NHAP)
                .WithOptional(e => e.ACCOUNT_NHAN_VIEN)
                .HasForeignKey(e => e.ID_NV);

            modelBuilder.Entity<CHI_NHANH>()
                .Property(e => e.MaChiNhanh)
                .IsFixedLength();

            modelBuilder.Entity<CHI_NHANH>()
                .Property(e => e.TenChiNhanh)
                .IsFixedLength();

            modelBuilder.Entity<CHI_NHANH>()
                .Property(e => e.DiaChi)
                .IsFixedLength();

            modelBuilder.Entity<CHI_NHANH>()
                .HasMany(e => e.STK_NGAN_HANG)
                .WithOptional(e => e.CHI_NHANH)
                .HasForeignKey(e => e.ID);

            modelBuilder.Entity<CHI_NHANH>()
                .HasMany(e => e.KHACH_HANG)
                .WithOptional(e => e.CHI_NHANH)
                .HasForeignKey(e => e.MaCN);

            modelBuilder.Entity<CHI_NHANH>()
                .HasMany(e => e.NHAN_VIEN)
                .WithOptional(e => e.CHI_NHANH)
                .HasForeignKey(e => e.MaCN);

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.TenKhachHang)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.DiaChi)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .Property(e => e.MaCN)
                .IsFixedLength();

            modelBuilder.Entity<KHACH_HANG>()
                .HasOptional(e => e.ACCOUNT_KHACH_HANG)
                .WithRequired(e => e.KHACH_HANG);

            modelBuilder.Entity<KHACH_HANG>()
                .HasMany(e => e.STKs)
                .WithOptional(e => e.KHACH_HANG)
                .HasForeignKey(e => e.ID);

            modelBuilder.Entity<LAI_SUAT>()
                .Property(e => e.KyHan)
                .IsFixedLength();

            modelBuilder.Entity<LAI_SUAT>()
                .HasMany(e => e.LICH_SU_GUI_TIET_KIEM)
                .WithOptional(e => e.LAI_SUAT)
                .HasForeignKey(e => e.IDLaiSuat);

            modelBuilder.Entity<LICH_SU_DANG_NHAP>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_DANG_NHAP>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_GUI_TIET_KIEM>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_GUI_TIET_KIEM>()
                .Property(e => e.STK)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_KHACH_HANG_GIAO_DICH>()
                .Property(e => e.MaGiaoDich)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_KHACH_HANG_GIAO_DICH>()
                .Property(e => e.STKChuyen)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_KHACH_HANG_GIAO_DICH>()
                .Property(e => e.STKNhan)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_KHACH_HANG_GIAO_DICH>()
                .Property(e => e.NoiDung)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_MO_KHOA_THE>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_MO_KHOA_THE>()
                .Property(e => e.STK)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_CHUYEN_TIEN>()
                .Property(e => e.MaGiaoDich)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_CHUYEN_TIEN>()
                .Property(e => e.STKChuyen)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_CHUYEN_TIEN>()
                .Property(e => e.STKNhan)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_CHUYEN_TIEN>()
                .Property(e => e.NoiDung)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_NHAN_TIEN>()
                .Property(e => e.MaGiaoDich)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_NHAN_TIEN>()
                .Property(e => e.STKChuyen)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_NHAN_TIEN>()
                .Property(e => e.STKNhan)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NGAN_HANG_NHAN_TIEN>()
                .Property(e => e.NoiDung)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NHAN_VIEN_DANG_NHAP>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<LICH_SU_NHAN_VIEN_DANG_NHAP>()
                .Property(e => e.ID_NV)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.TenNhanVien)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.CMND)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.DiaChi)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.MaCN)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<NHAN_VIEN>()
                .HasOptional(e => e.ACCOUNT_NHAN_VIEN)
                .WithRequired(e => e.NHAN_VIEN);

            modelBuilder.Entity<QUAN_HUYEN>()
                .HasMany(e => e.CHI_NHANH)
                .WithOptional(e => e.QUAN_HUYEN)
                .HasForeignKey(e => new { e.ID_Tinh, e.ID_Huyen });

            modelBuilder.Entity<QUAN_HUYEN>()
                .HasMany(e => e.KHACH_HANG)
                .WithOptional(e => e.QUAN_HUYEN)
                .HasForeignKey(e => new { e.ID_Tinh, e.ID_Huyen });

            modelBuilder.Entity<QUAN_HUYEN>()
                .HasMany(e => e.NHAN_VIEN)
                .WithOptional(e => e.QUAN_HUYEN)
                .HasForeignKey(e => new { e.ID_Tinh, e.ID_Huyen });

            modelBuilder.Entity<STK>()
                .Property(e => e.STK1)
                .IsFixedLength();

            modelBuilder.Entity<STK>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_GUI_TIET_KIEM)
                .WithOptional(e => e.STK1)
                .HasForeignKey(e => e.STK);

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_KHACH_HANG_GIAO_DICH)
                .WithOptional(e => e.STK)
                .HasForeignKey(e => e.STKChuyen);

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_KHACH_HANG_GIAO_DICH1)
                .WithOptional(e => e.STK1)
                .HasForeignKey(e => e.STKNhan);

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_MO_KHOA_THE)
                .WithOptional(e => e.STK1)
                .HasForeignKey(e => e.STK);

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_NGAN_HANG_CHUYEN_TIEN)
                .WithOptional(e => e.STK)
                .HasForeignKey(e => e.STKNhan);

            modelBuilder.Entity<STK>()
                .HasMany(e => e.LICH_SU_NGAN_HANG_NHAN_TIEN)
                .WithOptional(e => e.STK)
                .HasForeignKey(e => e.STKChuyen);

            modelBuilder.Entity<STK_NGAN_HANG>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<STK_NGAN_HANG>()
                .Property(e => e.STK)
                .IsFixedLength();

            modelBuilder.Entity<STK_NGAN_HANG>()
                .HasMany(e => e.LICH_SU_NGAN_HANG_CHUYEN_TIEN)
                .WithOptional(e => e.STK_NGAN_HANG)
                .HasForeignKey(e => e.STKChuyen);

            modelBuilder.Entity<STK_NGAN_HANG>()
                .HasMany(e => e.LICH_SU_NGAN_HANG_NHAN_TIEN)
                .WithOptional(e => e.STK_NGAN_HANG)
                .HasForeignKey(e => e.STKNhan);

            modelBuilder.Entity<TINH_THANH>()
                .HasMany(e => e.QUAN_HUYEN)
                .WithRequired(e => e.TINH_THANH)
                .HasForeignKey(e => e.ID_Tinh)
                .WillCascadeOnDelete(false);
        }
    }
}
