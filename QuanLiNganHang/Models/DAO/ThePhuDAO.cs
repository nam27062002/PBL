using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Models.DAO
{
    public class ThePhuDAO
    {
        public STK ThePhu { get; set; }
        private static ThePhuDAO _Instance;
        public static ThePhuDAO Instance
        {
            get { return _Instance ?? (_Instance = new ThePhuDAO()); }
            set { }
        }
        private ThePhuDAO() { ThePhu = new STK(); }
        public void AddThePhu(string STK, string ID)
        {
            ThePhu.STK1 = STK;
            ThePhu.NgayCap = DateTime.Now;
            ThePhu.ID = ID;
            ThePhu.SoDu = 0;
            ThePhu.Main = false;
            ThePhu.TrangThai = true;
            STK a = new STK { STK1 = STK,NgayCap = DateTime.Now,ID = ID,Main = false,TrangThai = true,SoDu = 0};
            QuanLiNganHangDbContext.Instance.STKs.Add(a);
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
    }
}