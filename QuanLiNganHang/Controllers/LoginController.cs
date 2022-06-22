using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        // Input: user + password | output: valid ? true : false
        [HttpPost]
        public JsonResult CheckAccount(string User, string Password)
        {
            return Json(AccountDAO.Instance.CheckAccount(User, Password), JsonRequestBehavior.AllowGet);
        }
    }
}