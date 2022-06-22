using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.LIB;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class ThucHienChuyenTienController : Controller
    {
        // GET: ThucHienChuyenTien
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ConvertMoney(string SoTien)
        {
            return Json(Function.Instance.ConvertMoneyToMoney(SoTien), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckMoney(string SoTien)
        {
            return Json(Customer.Instance.CheckSoDuSTKchuyen(SoTien), JsonRequestBehavior.AllowGet);
        }
        public string NoiDungGiaoDich()
        {
            return Customer.Instance.NoiDungGiaoDich();
        }
        [HttpPost]
        public JsonResult GetString(string SoTien, string NoiDung)
        {
            ChuyenTienDAO.Instance.SetTime_Money_Content(SoTien, NoiDung);
            return Json(JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult StringMoney(string SoTien)
        {
            return Json(Function.Instance.deletestring(Function.Instance.ConvertLongToStringMoney(Function.Instance.ConvertMoneyToLong(SoTien))), JsonRequestBehavior.AllowGet);
        }
       
    }
}