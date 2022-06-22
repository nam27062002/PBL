using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Models.DAO
{
    public class ChuyenTienDAO
    {
        public LICH_SU_KHACH_HANG_GIAO_DICH ls;
        private static ChuyenTienDAO _Instance;
        public static ChuyenTienDAO Instance
        {
            get { return _Instance ?? (_Instance = new ChuyenTienDAO()); }
            set { }
        }
        private ChuyenTienDAO()
        {
            ls = new LICH_SU_KHACH_HANG_GIAO_DICH();
        }
        public void SetSTKChuyenNhan(string STKChuyen,string STKNhan)
        {
            ls.STKChuyen = STKChuyen;
            ls.STKNhan = STKNhan;
        }
        public void SetTime_Money_Content(string money,string content)
        {
            ls.SoTien = Function.Instance.ConvertMoneyToLong(money);
            ls.NoiDung = content;
            ls.NgayChuyen = DateTime.Now;
        }
        private void SetIDLSGD()
        {
            ls.MaGiaoDich = CreateIDLichSuChuyenTien();
        }
        public void SaveLSGDKH()
        {
            SetIDLSGD();
            ChuyenTien(); 
            LICH_SU_KHACH_HANG_GIAO_DICH ls1 = new LICH_SU_KHACH_HANG_GIAO_DICH
            {
                MaGiaoDich = ls.MaGiaoDich,
                STKChuyen = ls.STKChuyen,
                STKNhan = ls.STKNhan,
                NgayChuyen = ls.NgayChuyen,
                SoTien = ls.SoTien,
                NoiDung = ls.NoiDung
            };
            QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.Add(ls1);
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        private void ChuyenTien()
        {
            try
            {
                QuanLiNganHangDbContext.Instance.STKs.Find(ls.STKChuyen).SoDu -= ls.SoTien;
                QuanLiNganHangDbContext.Instance.STKs.Find(ls.STKNhan).SoDu += ls.SoTien;
                QuanLiNganHangDbContext.Instance.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        private string CreateIDLichSuChuyenTien()
        {
            string ID;
            if (QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.Count() == 0)
            {
                ID = "100000";
            }
            else
            {
                var data = QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.ToList();
                ID = (Convert.ToInt64((data[data.Count() - 1].MaGiaoDich).Remove(0,1)) + 1).ToString();
            }
            return "A"+ID;
        }
        public string GetNameSTKNhan()
        {
            return GetDataFromDatabaseDAO.Instance.GetNameCustomerBySTK(ls.STKNhan);
        }
        public string ConvertMoney()
        {
            return Function.Instance.ConvertLongToMoney(Convert.ToInt64(ls.SoTien));
        }

    }
}