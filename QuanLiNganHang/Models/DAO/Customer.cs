using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
using QuanLiNganHang.Models.Lib;
namespace QuanLiNganHang.Models.DAO
{
    public class Customer
    {
        public KHACH_HANG customer { get; set; }
        public List<STK> ListSTK { get; set; }
        public STK STKChinh { get; set; }
        private static Customer _Instance;
        public static Customer Instance
        {
            get { return _Instance ?? (_Instance = new Customer()); }
            set { }
        }
        private Customer()
        {
            customer = new KHACH_HANG();
            ListSTK = new List<STK>();
        }
        public void SetCustomer(string SDT)
        {
            customer = QuanLiNganHangDbContext.Instance.KHACH_HANG.Find(SDT);
            SetListSTK();
            SetSTKChinh();
        }
        private void SetListSTK()
        {
            ListSTK = QuanLiNganHangDbContext.Instance.STKs.Where(p => p.ID == customer.SDT).ToList();
        }
        private void SetSTKChinh()
        {
            STKChinh = QuanLiNganHangDbContext.Instance.STKs.Where(p => p.ID == customer.SDT && p.Main == true).SingleOrDefault();
        }
        public string GetSoDu(STK stk)
        {
            return Function.Instance.ConvertLongToMoney(Convert.ToInt64(stk.SoDu));
        }
        public bool CheckSoDuSTKchuyen(string money)
        {
            if (Function.Instance.ConvertMoneyToLong(money) > STKChinh.SoDu)
                return false;
            return true;
        }
        public string NoiDungGiaoDich() { return QuanLiNganHangDbContext.Instance.KHACH_HANG.Find(STKChinh.ID).TenKhachHang.Trim()+" Chuyển tiền"; }
        public void AddSTK(string STK)
        {
            ThePhuDAO.Instance.AddThePhu(STK, STKChinh.ID);
            ListSTK.Add(QuanLiNganHangDbContext.Instance.STKs.Find(STK));
            SaveLichSuMuaSTK();
        }
        public void SaveLichSuMuaSTK()
        {
            ChuyenTienMuaTaiKhoan();
            LICH_SU_NGAN_HANG_NHAN_TIEN ls = new LICH_SU_NGAN_HANG_NHAN_TIEN();
            ls.MaGiaoDich = CreateIDNHNT();
            ls.STKChuyen = STKChinh.STK1;
            ls.STKNhan = QuanLiNganHangDbContext.Instance.STK_NGAN_HANG.Where(p => p.ID == customer.MaCN).SingleOrDefault().STK;
            ls.SoTien = 5000000;
            ls.NgayChuyen = DateTime.Now;
            ls.NoiDung = "Phí mua tài khoản như ý";
            QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_NHAN_TIEN.Add(ls);
            QuanLiNganHangDbContext.Instance.SaveChanges();
            SeenEmail.Instance.SeenNewSTK(customer.Email, STKChinh.STK1, customer.TenKhachHang, Convert.ToDateTime(ls.NgayChuyen), Convert.ToInt64(STKChinh.SoDu));
        }
        public void SaveLichSuTietKiem(long sotien)
        {
            ChuyenTienMuaTaiKhoan();
            LICH_SU_NGAN_HANG_NHAN_TIEN ls = new LICH_SU_NGAN_HANG_NHAN_TIEN();
            ls.MaGiaoDich = CreateIDNHNT();
            ls.STKChuyen = STKChinh.STK1;
            ls.STKNhan = QuanLiNganHangDbContext.Instance.STK_NGAN_HANG.Where(p => p.ID == customer.MaCN).SingleOrDefault().STK;
            ls.SoTien = sotien;
            ls.NgayChuyen = DateTime.Now;
            ls.NoiDung = "Gửi tiết kiệm";
            QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_NHAN_TIEN.Add(ls);
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        private string CreateIDNHNT()
        {
            string ID;
            if (QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_NHAN_TIEN.Count() == 0)
            {
                ID = "100000";
            }
            else
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_NHAN_TIEN.ToList();
                ID = (Convert.ToInt64((data[data.Count() - 1].MaGiaoDich).Remove(0, 1)) + 1).ToString();
            }
            return "B" + ID;
        }
        private void ChuyenTienMuaTaiKhoan()
        {
            STKChinh.SoDu -= 5000000;
            QuanLiNganHangDbContext.Instance.STK_NGAN_HANG.Where(p => p.ID == customer.MaCN).SingleOrDefault().SoDu += 5000000;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        public void ChuyenTienGuiTietKiem(long sotien)
        {
            STKChinh.SoDu -= sotien;
            QuanLiNganHangDbContext.Instance.STK_NGAN_HANG.Where(p => p.ID == customer.MaCN).SingleOrDefault().SoDu += sotien;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        public string TrangThaiThe(string STK)
        {
            if (QuanLiNganHangDbContext.Instance.STKs.Find(STK).TrangThai == true)
                return "Đang hoạt động";
            else
                return "Đã khóa";
        }
        public bool CheckMainSTK(string STK)
        {
            if (STK == STKChinh.STK1)
                return true;
            return false;
        }
        public void SaveLichSuKhoaThe(string stk, string reason)
        {
            QuanLiNganHangDbContext.Instance.LICH_SU_MO_KHOA_THE.Add(new LICH_SU_MO_KHOA_THE { ID = CreateIDLichSuKhoaThe(), STK = stk, NgayKhoaThe = DateTime.Now, LiDoKhoaThe = reason });
            STKChinh.TrangThai = false;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        public void SaveLichSuMoThe(string stk)
        {
            QuanLiNganHangDbContext.Instance.LICH_SU_MO_KHOA_THE.Where(p => p.STK == stk && p.NgayMoThe == null).SingleOrDefault().NgayMoThe = DateTime.Now;
            STKChinh.TrangThai = true;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        private string CreateIDLichSuKhoaThe()
        {
            string ID;
            if (QuanLiNganHangDbContext.Instance.LICH_SU_MO_KHOA_THE.Count() == 0)
            {
                ID = "1000000";
            }
            else
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_MO_KHOA_THE.ToList();
                ID = (Convert.ToInt64(data[data.Count() - 1].ID) + 1).ToString();
            }
            return ID;
        }
        public void ChangeMainSTK(string STK)
        {
            STKChinh = QuanLiNganHangDbContext.Instance.STKs.Find(STK);
            STKChinh.Main = true;
            foreach (var i in ListSTK)
            {
                if (i.STK1 != STK)
                    i.Main = false;
            }
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        public string NgayCapThe(STK stk)
        {   
            DateTime dt = Convert.ToDateTime(stk.NgayCap);
            return dt.Day + "/" + dt.Month + "/" + dt.Year;
        }
        public string ConvertLongToMoney(STK stk)
        {
            return Function.Instance.ConvertLongToMoney(Convert.ToInt64(stk.SoDu));
        }
        public STK GetSTK(int index)
        {
            return ListSTK[index-1];
        }
        public string GetNameChiNhanh()
        {
            return QuanLiNganHangDbContext.Instance.CHI_NHANH.Find(customer.MaCN).TenChiNhanh;
        }
        public dynamic GetListCT()
        {
            var data = QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.Where(p => p.STKChuyen == STKChinh.STK1).ToList();
            data.Reverse();
            return data;
        }
        public int GetCount()
        {
            return QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.Where(p => p.STKChuyen == STKChinh.STK1).Count();
        }
    }
}