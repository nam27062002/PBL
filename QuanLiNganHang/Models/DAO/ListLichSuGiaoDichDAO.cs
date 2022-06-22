using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.LIB;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Models.DAO
{
    public class ListLichSuGiaoDichDAO
    {
        public STK stk { get; set; }
        public List<LichSuGiaoDich> ls;
        private static ListLichSuGiaoDichDAO _Instance;
        public static ListLichSuGiaoDichDAO Instance
        {
            get { return _Instance ?? (_Instance = new ListLichSuGiaoDichDAO()); }
            set { }
        }
        private ListLichSuGiaoDichDAO()
        {
            ls = new List<LichSuGiaoDich>();
            stk = new STK();
        }
        public void SetSTK(STK stk)
        {
            ls = new List<LichSuGiaoDich>();
            this.stk = stk;
            LoadListKHGD();
            LoadListNHCT();
            LoadListNHNT();
            ls.Sort((x, y) => DateTime.Compare(y.NgayChuyen,x.NgayChuyen));
        }
        private void LoadListKHGD()
        { 
            var data = QuanLiNganHangDbContext.Instance.LICH_SU_KHACH_HANG_GIAO_DICH.ToList();
            SetData(data);
        }
        private void LoadListNHNT()
        {
            LichSuGiaoDich htr = new LichSuGiaoDich();
            var data = QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_NHAN_TIEN.ToList();
            SetData(data);
        }
        private void LoadListNHCT()
        {
            LichSuGiaoDich htr = new LichSuGiaoDich();
            var data = QuanLiNganHangDbContext.Instance.LICH_SU_NGAN_HANG_CHUYEN_TIEN.ToList();
            SetData(data);
        }
        private void SetData(dynamic data)
        {
            foreach (var item in data)
            {
                if (stk.STK1.Trim() == item.STKChuyen.Trim() || stk.STK1.Trim() == item.STKNhan.Trim())
                {
                    LichSuGiaoDich htr = new LichSuGiaoDich();
                    htr.ID = item.MaGiaoDich;
                    htr.STKNhan = item.STKNhan;
                    htr.STKChuyen = item.STKChuyen;
                    htr.NgayChuyen = Convert.ToDateTime(item.NgayChuyen);
                    htr.NoiDung = item.NoiDung;
                    htr.SoTien = Convert.ToInt64(item.SoTien);
                    ls.Add(htr);
                }
            }
        }
        public string GetSoDu()
        {
            return Function.Instance.ConvertLongToMoney1(Convert.ToInt64(stk.SoDu));
        }
    }
}