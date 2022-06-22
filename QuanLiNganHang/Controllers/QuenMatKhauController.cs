using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
using QuanLiNganHang.Models.Lib;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Controllers
{
    public class QuenMatKhauController : Controller
    {
        // GET: QuenMatKhau
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetData(string SDT, string Email, string Name, string NS, string CMND)
        {
            return Json(ForgetPassDAO.Instance.CheckInfo(SDT, Email, Name, NS, CMND), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetOTP(string OTP)
        {
            return Json(SeenEmail.Instance.CheckOTP(OTP), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetNotifyReturnPass()
        {
            return Json(ForgetPassDAO.Instance.NotifyReturnPass(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult SaveAndSeenNewPassword()
        {
            ForgetPassDAO.Instance.SaveRandomPassAndSeenEmail();
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}