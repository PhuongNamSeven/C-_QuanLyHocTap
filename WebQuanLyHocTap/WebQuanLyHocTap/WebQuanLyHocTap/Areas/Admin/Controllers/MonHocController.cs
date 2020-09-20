using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Models;

namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class MonHocController : Controller
    {
        // GET: Admin/MonHoc
        public ActionResult Index(string search, int page = 1, int pageSize = 4)
        {
            var dao = new AdminDAO();
            var model = dao.ListAllPaging4(search, page, pageSize);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gv = new AdminDAO().ViewDetailMonHoc(id);
            return View(gv);
        }
        [HttpPost]
        public ActionResult Edit(MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.UpdateMonHoc(monHoc);
                if (result)
                {
                    return RedirectToAction("Index", "MonHoc");
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
            var dao = new AdminDAO().XoaMonHoc(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(MonHoc monHoc)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                long result = dao.Themmh(monHoc);
                if (result > 0)
                {
                    return RedirectToAction("Index", "MonHoc");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thanh cong");
                }
            }
            return View("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new AdminDAO().ChuyenTrangThaiMonHoc(id);
            return Json(new
            {
                islock = result
            });
        }
       
    }
}