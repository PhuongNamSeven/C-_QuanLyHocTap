using System.Web.Mvc;

namespace WebQuanLyHocTap.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index",id = UrlParameter.Optional },
                new { controller = "Login|GiangVien|SinhVien|MonHoc|Signin|LopHoc" },
                 new[] { "WebQuanLyHocTap.Areas.Admin.Controllers" }
            );
        }
    }
}