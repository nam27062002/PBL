using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class DoiMatKhauController : Controller
    {
        // GET: DoiMatKhau
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckPass(string Pass)
        {
            return Json(AccountDAO.Instance.CheckPass(Pass), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChangePass(string Pass)
        {
            AccountDAO.Instance.ChangeNewPassword(Pass);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}