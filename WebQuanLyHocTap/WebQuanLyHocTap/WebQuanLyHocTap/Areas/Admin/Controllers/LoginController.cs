using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyHocTap.Areas.Admin.Models;
using WebQuanLyHocTap.Common;

namespace WebQuanLyHocTap.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string UserName,string Password)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDAO(); // xu ly
                var result = dao.Login(UserName, Password);
                if (result ==1)
                {
                    var admin = dao.GetByName(UserName); //lay username cua admin
                   
                    var adminSession = new AdminLogin(); // lay thuoc tinh doi tuong danh nhap
                   
                    adminSession.UserName = admin.UserName;
                    adminSession.AdminID = admin.AdminID;
                  
                    Session.Add(CommonConstants.USER_SESSION,adminSession);
                  
                    return RedirectToAction("Index", "GiangVien");
                }
                else if(result ==0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if(result == -2)
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