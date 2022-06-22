using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
using QuanLiNganHang.Models.Lib;
namespace QuanLiNganHang.Models.DAO
{
    public class ForgetPassDAO
    {
        private KHACH_HANG customer { get; set; } 
        private static ForgetPassDAO _Instance;
        public static ForgetPassDAO Instance
        {
            get { return _Instance ?? (_Instance = new ForgetPassDAO()); }
            set { }
        }
        private ForgetPassDAO()
        {
            customer = new KHACH_HANG();
        }
        public bool CheckInfo(string SDT, string Email, string Name, string NS, string CMND)
        {
            customer.SDT = SDT;
            customer.Email = Email;
            customer.TenKhachHang = Name;
            customer.NgaySinh = Convert.ToDateTime(NS).Date;
            customer.CMND = CMND;
            if (QuanLiNganHangDbContext.Instance.KHACH_HANG.Where(p => p.SDT == SDT && p.Email == Email && p.TenKhachHang == Name && p.CMND == CMND && p.NgaySinh == customer.NgaySinh).Count() != 0)
            {
                SeenEmail.Instance.SeenOTPForgetPass(Email, Name, SDT);
                return true;
            }
            else
            {
                return false;
            }
        }
        public string NotifyReturnPass()
        {
            return Function.Instance.NotifyReturnPass(customer.SDT, customer.Email);
        }
        public void SaveRandomPassAndSeenEmail()
        {
            SeenEmail.Instance.SeenNewPassword(customer.Email,customer.TenKhachHang,customer.SDT);
            QuanLiNganHangDbContext.Instance.ACCOUNT_KHACH_HANG.Where(p => p.UserName == customer.SDT).SingleOrDefault().Pass = SeenEmail.Instance.Pass;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
    }
}