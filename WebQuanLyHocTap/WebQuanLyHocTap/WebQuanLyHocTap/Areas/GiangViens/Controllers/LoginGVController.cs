using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Common;

namespace WebQuanLyHocTap.Areas.GiangViens.Controllers
{
    public class LoginGVController : Controller
    {
        // GET: GiangViens/LoginGV
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string UserName, string Password)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO(); // xu ly
                var result = dao.Login2(UserName, Password);
                if (result == 1)
                {
                    var giangvien = dao.GetByName2(UserName); //lay username cua admin

                    var giangvienSession = new GiangVienLogin(); // lay thuoc tinh doi tuong danh nhap

                    giangvienSession.UserName = giangvien.UserName;
                    giangvienSession.GiangVienID = giangvien.GiangVienID;

                    Session.Add(CommonConstants.GIANGVIEN_SESSION, giangvienSession);

                    return RedirectToAction("Index", "GVHome");
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