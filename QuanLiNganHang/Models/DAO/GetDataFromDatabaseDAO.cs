using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Models.DAO
{
    public class GetDataFromDatabaseDAO
    {
        private static GetDataFromDatabaseDAO _Instance;
        public static GetDataFromDatabaseDAO Instance
        {
            get { return _Instance ?? (_Instance = new GetDataFromDatabaseDAO()); }
            set { }
        }
        public dynamic GetListLaiSuat()
        {
            return QuanLiNganHangDbContext.Instance.LAI_SUAT.ToList();
        }
        public string GetNameCustomerBySTK(string STK)
        {
            if (QuanLiNganHangDbContext.Instance.STKs.Where(p => p.STK1 == STK).Count() > 0)
            {
                return QuanLiNganHangDbContext.Instance.KHACH_HANG.Find(QuanLiNganHangDbContext.Instance.STKs.Find(STK).ID).TenKhachHang;
            }
            else
            {
                return "Error";
            }
                
        }
        public bool CheckSTK(string STK)
        {
            if (QuanLiNganHangDbContext.Instance.STKs.Where(p => p.STK1 == STK).Count() > 0)
            {
                return true;
            }
            return false;
        }
        public dynamic GetListTinhThanh()
        {
            return QuanLiNganHangDbContext.Instance.TINH_THANH.ToList();
        }
        public dynamic GetNameDistrictByProvince(string Province)
        {
            return QuanLiNganHangDbContext.Instance.QUAN_HUYEN.Where(p => p.TINH_THANH.TenTinhThanh == Province).ToList();
        }
        private List<CHI_NHANH> GetAllAddressChiNhanh()
        {
            return QuanLiNganHangDbContext.Instance.CHI_NHANH.ToList();
        }
        public List<string> GetAddress()
        {
            List<string> data = new List<string>();
            foreach (var  i in GetAllAddressChiNhanh())
            {
                data.Add(i.DiaChi + ", "+ GetNameDistrictByID(Convert.ToInt32(i.ID_Tinh),Convert.ToInt32(i.ID_Huyen)) + ", " + GetNameProvinceByID(Convert.ToInt32(i.ID_Tinh)));
            }
            return data;
        }
        private string GetNameProvinceByID(int ID)
        {
            return QuanLiNganHangDbContext.Instance.TINH_THANH.Find(ID).TenTinhThanh;
        }
        private string GetNameDistrictByID(int IDT,int IDH)
        {
            return QuanLiNganHangDbContext.Instance.QUAN_HUYEN.Where(p => p.ID_Tinh == IDT & p.ID_Huyen == IDH).SingleOrDefault().TenHuyen;
        }
        public double GetLaiSuatByKiHan(string str)
        {
            return Convert.ToDouble(QuanLiNganHangDbContext.Instance.LAI_SUAT.Where(p => p.KyHan == str.Trim()).SingleOrDefault().LaiSuat);
        }
        public string TinhLaiSuat(string money,string kihan)
        {
            string kh = "";
            for(int i = 0; i < kihan.Length; i++)
            {
                if (kihan[i] == ' ')
                {
                    break;
                }
                else
                {
                    kh += kihan[i];
                }
            }
            return Function.Instance.TinhLaiSuat(money, GetLaiSuatByKiHan(kihan), Convert.ToInt32(kh));
        }
    }
}