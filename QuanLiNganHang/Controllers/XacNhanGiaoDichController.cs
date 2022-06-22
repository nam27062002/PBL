using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class XacNhanGiaoDichController : Controller
    {
        // GET: XacNhanChuyenTien
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SaveHistoryKHGD()
        {
            ChuyenTienDAO.Instance.SaveLSGDKH();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}