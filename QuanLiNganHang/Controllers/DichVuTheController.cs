using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class DichVuTheController : Controller
    {
        // GET: DichVuThe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetState(string STK)
        {
            return Json(Customer.Instance.TrangThaiThe(STK), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveLichSuKhoaThe(string STK, string reason)
        {
            Customer.Instance.SaveLichSuKhoaThe(STK, reason);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SaveLichSuMoThe(string STK)
        {
            Customer.Instance.SaveLichSuMoThe(STK);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ChangeMainSTK(string STK)
        {
            Customer.Instance.ChangeMainSTK(STK);
            return Json(Customer.Instance.NgayCapThe(Customer.Instance.STKChinh), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public string GetSTK() { return Customer.Instance.STKChinh.STK1; }
    }
}