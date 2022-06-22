using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Models.DAO
{
    public class SavingAccountDAO
    {
        public LICH_SU_GUI_TIET_KIEM ls;
        private static SavingAccountDAO _Instance;
        public static SavingAccountDAO Instance
        {
            get { return _Instance ?? (_Instance = new SavingAccountDAO()); }
            set { }
        }
        private SavingAccountDAO()
        {
            ls = new LICH_SU_GUI_TIET_KIEM();
        }
        public void CreateSavingAccount(string Sotien,string Kihan)
        {
            ls.IDLaiSuat = QuanLiNganHangDbContext.Instance.LAI_SUAT.Where(p => p.KyHan == Kihan).SingleOrDefault().ID;
            ls.STK = Customer.Instance.STKChinh.STK1;
            ls.SoTien = Function.Instance.ConvertMoneyToLong(Sotien);
            ls.NgayGui = DateTime.Now;
        }
        public string Money()
        {
            return Function.Instance.ConvertLongToMoney(Convert.ToInt64(ls.SoTien));
        }
        public LAI_SUAT GetLaiSuat()
        {
            return QuanLiNganHangDbContext.Instance.LAI_SUAT.Find(ls.IDLaiSuat);
        }
        public void SaveLS()
        {
            LICH_SU_GUI_TIET_KIEM a = new LICH_SU_GUI_TIET_KIEM();
            ls.ID = CreateIDLichSuChuyenTien();
            a.ID = CreateIDLichSuChuyenTien();
            a.SoTien = ls.SoTien;
            a.NgayGui = ls.NgayGui;
            a.IDLaiSuat = ls.IDLaiSuat;
            a.STK = ls.STK;
            Customer.Instance.ChuyenTienGuiTietKiem(Convert.ToInt64(a.SoTien));
            Customer.Instance.SaveLichSuTietKiem(Convert.ToInt64(a.SoTien));
            QuanLiNganHangDbContext.Instance.LICH_SU_GUI_TIET_KIEM.Add(a);
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        private string CreateIDLichSuChuyenTien()
        {
            string ID;
            if (QuanLiNganHangDbContext.Instance.LICH_SU_GUI_TIET_KIEM.Count() == 0)
            {
                ID = "100000";
            }
            else
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_GUI_TIET_KIEM.ToList();
                ID = (Convert.ToInt64((data[data.Count() - 1].ID).Remove(0, 1)) + 1).ToString();
            }
            return "D" + ID;
        }
    }
}