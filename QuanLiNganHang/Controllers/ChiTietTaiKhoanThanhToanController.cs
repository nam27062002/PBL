using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class ChiTietTaiKhoanThanhToanController : Controller
    {
        // GET: ChiTietTaiKhoanThanhToan
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult list()
        {
            return Json(ListLichSuGiaoDichDAO.Instance.ls, JsonRequestBehavior.AllowGet);
        }
    }
}