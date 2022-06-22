using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class XacNhanGuiTietKiemController : Controller
    {
        // GET: XacNhanGuiTietKiem
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Save()
        {
            SavingAccountDAO.Instance.SaveLS();
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}