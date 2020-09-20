using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Models;

namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class SigninController : Controller
    {
        // GET: Admin/Signin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(QuanTri quantri)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO();
                long id = dao.Insert(quantri);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ModelState.AddModelError("", "Them khong thanh cong");
                }
            }
            return View("Index");
        }
    }
}