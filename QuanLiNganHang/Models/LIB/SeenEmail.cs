using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using QuanLiNganHang.Models.EF;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Models.Lib
{
    public class SeenEmail
    {
        private MailMessage msg;
        private SmtpClient client;
        private string OTP;
        public string Pass;
        private static SeenEmail _Instance;
        public static SeenEmail Instance
        {
            get { return _Instance ?? (_Instance = new SeenEmail()); }
            set { }
        }
        private SeenEmail()
        {
            msg = new MailMessage();
            client = new SmtpClient();
            msg.From = new MailAddress("pbl3quanlinganhang@gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("pbl3quanlinganhang@gmail.com", "yfhiqrwvbnuvykal");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
        }
        public void SeenOTPForgetPass(string Email,string TenKhachHang,string SDT)
        {
            OTP = Function.Instance.OTPForgetPass();
            msg.To.Add(Email);
            msg.Subject = "SmartBank OTP Request";
            string message = "<p style='font-size:20px;'>Xin chào " + TenKhachHang + "</p>";
            message += "<p>Gần đây bạn vừa yêu cầu cấp lại mật khẩu cho tài khoản: " + SDT + "</p>";
            message += "<p>Nếu đó là yêu cầu của bạn, mã OTP lấy lại mật khẩu của bạn là:</p>";
            message += "<p style='font-size:20px'>" + OTP + "</p>";
            message += "<p>Nếu đây không phải là yêu cầu của bạn hãy bỏ qua email này.</p>";
            msg.Body = message;
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
        public bool CheckOTP(string OTP)
        {
            if (this.OTP == OTP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SeenNewPassword(string Email,string Name,string SDT)
        {
            Pass = Function.Instance.NewPass();
            msg.To.Add(Email);
            msg.Subject = "SmartBank Password Reset Request"; 
            string message = "<p style='font-size:20px;'>Xin chào " + Name + "</p>";
            message += "<p>Gần đây bạn vừa yêu cầu cấp lại mật khẩu cho tài khoản: " + SDT + "</p>";
            message += "<p>Nếu đó là yêu cầu của bạn, mật khẩu để đăng nhập vào tài khoản của bạn là:</p>";
            message += "<p style='font-size:20px'>" + Pass + "</p>";
            message += "<p>Nếu đây không phải là yêu cầu của bạn hãy bỏ qua email này.</p>";
            msg.Body = message;
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
        public void SeenNewSTK(string Email,string STK,string Name,DateTime time,long SoDu)
        {
            msg.To.Add(Email);
            msg.Subject = "SmarkBank Notice";
            string message = "<p style='font-size:20px;'>Xin chào " + Name + "</p>";
            message += "<p>Tài khoản "+STK+" bị trừ 5,000,000 VND vào lúc "+time+"</p>";
            message += "<p>Số dư còn lại của bạn là: "+Function.Instance.ConvertLongToMoney(SoDu)+"</p>";
            message += "<p>Nội dung: Phí dịch vụ mở tài khoản như ý</p>";
            message += "<p>Cảm ơn bạn đã sử dụng dịch vụ.</p>";
            msg.Body = message;
            msg.IsBodyHtml = true;
            client.Send(msg);
        }
    }
}