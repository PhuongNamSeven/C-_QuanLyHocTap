using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Models;
using PagedList;
namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: Admin/SinhVien
        public ActionResult Index(string search,int page = 1, int pageSize = 4)
        {
            var dao = new AdminDAO();
            var model = dao.ListAllPaging2(search,page, pageSize);
            ViewBag.search = search;
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var sv = new AdminDAO().ViewDetailSinhVien(id);
            return View(sv);
        }
        [HttpPost]
        public ActionResult Edit(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.UpdateSinhVien(sinhVien);
                if (result) 
                {
                    return RedirectToAction("Index", "SinhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thanh cong");
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            var dao = new AdminDAO().XoaSV(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                long result = dao.Themsv(sinhVien);

                if (result > 0)
                {
                    return RedirectToAction("Index", "SinhVien");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thanh cong");
                }
            }
            return View("Index");
        }
    }
}