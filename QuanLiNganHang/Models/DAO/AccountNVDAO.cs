using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Models.DAO
{
    public class AccountNVDAO
    {
        public ACCOUNT_NHAN_VIEN account { get; set; }
        private static AccountNVDAO _Instance;
        public static AccountNVDAO Instance
        {
            get { return _Instance ?? (_Instance = new AccountNVDAO()); }
            set { }
        }
        private AccountNVDAO()
        {
            account = new ACCOUNT_NHAN_VIEN();
        }
        public bool CheckAccount(string UserName, string Password)
        {
            account.UserName = UserName;
            account.Pass = Password;
            if (QuanLiNganHangDbContext.Instance.ACCOUNT_NHAN_VIEN.Where(p => p.UserName == UserName && p.Pass == Password).Count() != 0)
            {
                return true;
            }
            return false;
        }

    }
}