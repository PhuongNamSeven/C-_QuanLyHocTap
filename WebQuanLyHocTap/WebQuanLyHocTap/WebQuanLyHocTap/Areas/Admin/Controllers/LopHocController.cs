using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Models;

namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class LopHocController : Controller
    {
        // GET: Admin/LopHoc
        public ActionResult Index(string search, int page = 1, int pageSize = 4)
        {
            var dao = new AdminDAO();
            var model = dao.ListAllPaging3(search, page, pageSize);
            return View(model);
        }
       
       
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                long result = dao.ThemLopHoc(lopHocPhan);

                if (result > 0)
                {
                    return RedirectToAction("Index", "LopHoc");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thanh cong");
                }
            }
            return View("Index");
        }
        public ActionResult Delete(int id)
        {
            var dao = new AdminDAO().XoaLopHocPhan(id);
            return RedirectToAction("Index");
        }

    }
}