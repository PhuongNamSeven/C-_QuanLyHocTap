using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebQuanLyHocTap.Models;

namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class GiangVienController : Controller
    {
        // GET: Admin/GiangVien
        public ActionResult Index(string search,int page=1, int pageSize=4)
        {
            var dao = new AdminDAO();
            var model = dao.ListAllPaging(search,page, pageSize);
            ViewBag.search = search;
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gv = new AdminDAO().ViewDetailGiangVien(id);
            return View(gv);
        }
        [HttpPost]
        public ActionResult Edit(GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                var result = dao.Update(giangVien);
                if (result)
                {
                    return RedirectToAction("Index", "GiangVien");
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
            var dao = new AdminDAO().XoaGV(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult Create(GiangVien giangVien)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                long result = dao.Themgv(giangVien);
                if (result>0)
                {
                    return RedirectToAction("Index", "GiangVien");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thanh cong");
                }
            }
            return View("Index");
        }
    }
}