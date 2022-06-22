using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class MoTaiKhoanNhuYController : Controller
    {
        // GET: MoTaiKhoanNhuY
        public ActionResult Index()
        {
            return View();
        }
        // Kiểm tra xem tài khoản có tồn tại
        [HttpPost]
        public JsonResult CheckSTK(string STK)
        {
            return Json(GetDataFromDatabaseDAO.Instance.CheckSTK(STK), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetSTK(string STK)
        {
            Customer.Instance.AddSTK(STK);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}