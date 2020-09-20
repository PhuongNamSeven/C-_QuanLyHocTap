using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Common;

namespace WebQuanLyHocTap.Areas.SinhViens.Controllers
{
    public class LoginSVController : Controller
    {
        // GET: SinhViens/LoginSV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO(); // xu ly
                var result = dao.Login3(UserName, Password);
                if (result == 1)
                {
                    var sinhvien = dao.GetByName3(UserName); //lay username cua admin

                    var sinhvienSession = new SinhVienLogin(); // lay thuoc tinh doi tuong danh nhap

                    sinhvienSession.UserName = sinhvien.UserName;
                    sinhvienSession.SinhVienID = sinhvien.SinhVienID;

                    Session.Add(CommonConstants.SINHVIEN_SESSION, sinhvienSession);

                    return RedirectToAction("Index", "SVHome");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                }
            }


            return View("Index");
        }
    }
}