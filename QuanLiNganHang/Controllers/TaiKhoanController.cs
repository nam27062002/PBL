using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetSoThe()
        {
            return Json(Customer.Instance.ListSTK.Count(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult SetSTK(int index)
        {
            ListLichSuGiaoDichDAO.Instance.SetSTK(Customer.Instance.GetSTK(index));
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}