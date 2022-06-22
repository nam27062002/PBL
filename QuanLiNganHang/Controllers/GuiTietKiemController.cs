using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
using QuanLiNganHang.Models.LIB;
namespace QuanLiNganHang.Controllers
{
    public class GuiTietKiemController : Controller
    {
        // GET: GuiTietKiem
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetLaiSuatByKiHan(string Kihan)
        {
            return Json(GetDataFromDatabaseDAO.Instance.GetLaiSuatByKiHan(Kihan), JsonRequestBehavior.AllowGet);
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
        [HttpPost]
        public JsonResult StringMoney(string SoTien)
        {
            return Json(Function.Instance.deletestring(Function.Instance.ConvertLongToStringMoney(Function.Instance.ConvertMoneyToLong(SoTien))), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult TienLai(string money, string KiHan)
        {
            return Json(GetDataFromDatabaseDAO.Instance.TinhLaiSuat(money,KiHan), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CreateSavingAccount(string Sotien, string Kihan)
        {
            SavingAccountDAO.Instance.CreateSavingAccount(Sotien, Kihan);
            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}