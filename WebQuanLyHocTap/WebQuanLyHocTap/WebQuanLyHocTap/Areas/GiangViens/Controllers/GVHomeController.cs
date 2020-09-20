using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebQuanLyHocTap.Areas.GiangViens.Controllers
{
    public class GVHomeController : Controller
    {
        // GET: GiangViens/GVHome
        public ActionResult Index()
        {
            return View();
        }
    }
}