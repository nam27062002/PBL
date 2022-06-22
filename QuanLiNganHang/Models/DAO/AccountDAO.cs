using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Models.DAO
{
    public class AccountDAO
    {
        private ACCOUNT_KHACH_HANG account { get; set; }
        private static AccountDAO _Instance;
        public static AccountDAO Instance
        {
            get { return _Instance ?? (_Instance = new AccountDAO()); }
            set { }
        }
        private AccountDAO()
        {
            account = new ACCOUNT_KHACH_HANG();
        }
        public bool CheckAccount(string UserName,string Password)
        {
            account.UserName = UserName;
            account.Pass = Password;
            if (QuanLiNganHangDbContext.Instance.ACCOUNT_KHACH_HANG.Where(p => p.UserName == UserName && p.Pass == Password).Count() != 0)
            {
                Customer.Instance.SetCustomer(UserName);
                LastLoginDAO.Instance.SaveHistoryLogin(UserName);
                return true;
            }
            return false;
        }
        public void ChangeNewPassword(string NewPasword)
        {
            QuanLiNganHangDbContext.Instance.ACCOUNT_KHACH_HANG.Find(account.UserName).Pass = NewPasword;
            account.Pass = NewPasword;
            QuanLiNganHangDbContext.Instance.SaveChanges();
        }
        public bool CheckPass(string Password)
        {
            if (account.Pass == Password)
                return true;
            return false;
        }

    }
}