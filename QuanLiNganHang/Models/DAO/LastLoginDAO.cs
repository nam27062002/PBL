using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Models.DAO
{
    public class LastLoginDAO
    {
        private string SDT;
        public string DateLastLogin { get; set; }
        private static LastLoginDAO _Instance;
        public static LastLoginDAO Instance
        {
            get { return _Instance ?? (_Instance = new LastLoginDAO()); }
            set { }
        }
        // Lấy thời gian đăng nhập cuối cùng
        public string GetDayLastLogin()
        {
            if (QuanLiNganHangDbContext.Instance.LICH_SU_DANG_NHAP.Where(p => p.SDT == SDT).Count() > 0)
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_DANG_NHAP.Where(p => p.SDT == SDT).ToList();

                return data[data.Count - 1].NgayDangNhap.ToString();
            }
            else
            {
                return "Chưa từng đăng nhập";
            }
        }
        // Lưu lịch sử đăng nhập
        public void SaveHistoryLogin(string SDT)
        {
            this.SDT = SDT;
            DateLastLogin = GetDayLastLogin();
            QuanLiNganHangDbContext.Instance.LICH_SU_DANG_NHAP.Add(new LICH_SU_DANG_NHAP { ID = CreateIDLichSuDangNhap(), SDT = this.SDT, NgayDangNhap = DateTime.Now });
            QuanLiNganHangDbContext.Instance.SaveChanges();

        }
        // tạo mã giao dịch
        private string CreateIDLichSuDangNhap()
        {
            string ID;
            if (QuanLiNganHangDbContext.Instance.LICH_SU_DANG_NHAP.Count() == 0)
            {
                ID = "1000000";
            }
            else
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_DANG_NHAP.ToList();
                ID = (Convert.ToInt64(data[data.Count() - 1].ID) + 1).ToString();
            }
            return ID;
        }
    }
}