using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Areas.Admin.Controllers
{
    public class NVLoginController : Controller
    {
        // GET: Admin/NVLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult CheckAccount(string UserName,string Password)
        {
            return Json(AccountNVDAO.Instance.CheckAccount(UserName, Password),JsonRequestBehavior.AllowGet);
        }

    }
}