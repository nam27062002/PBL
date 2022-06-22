using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
using QuanLiNganHang.Models.EF;
namespace QuanLiNganHang.Controllers
{
    public class TimKiemChiNhanhATMController : Controller
    {
        // GET: TimKiemChiNhanhATM
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetNameDistrictByProvince(string Province)
        {
            QuanLiNganHangDbContext db = new QuanLiNganHangDbContext();
            bool proxyCreation = db.Configuration.ProxyCreationEnabled;
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var data = db.QUAN_HUYEN.Where(p => p.TINH_THANH.TenTinhThanh == Province).ToList();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message);
            }
            finally
            {
                db.Configuration.ProxyCreationEnabled = proxyCreation;
            }
        }
        [HttpGet]
        public JsonResult GetAddress()
        {
            return Json(GetDataFromDatabaseDAO.Instance.GetAddress(),JsonRequestBehavior.AllowGet);
        }
    }
}