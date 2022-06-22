using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiNganHang.Models.DAO;
namespace QuanLiNganHang.Controllers
{
    public class ChuyenTienController : Controller
    {
        // GET: ChuyenTien
        public ActionResult Index()
        {
            return View();
        }
        // Lấy tên khách hàng khi biết STK
        [HttpPost]
        public JsonResult GetNameKH(string STK)
        {
            ChuyenTienDAO.Instance.SetSTKChuyenNhan(Customer.Instance.STKChinh.STK1,STK);
            return Json(GetDataFromDatabaseDAO.Instance.GetNameCustomerBySTK(STK), JsonRequestBehavior.AllowGet);
        }
    }
}