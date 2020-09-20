using System.Web.Mvc;

namespace WebQuanLyHocTap.Areas.SinhViens
{
    public class SinhViensAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SinhViens";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SinhViens_default",
                "SinhViens/{controller}/{action}/{id}",
                 new { action = "Index", id = UrlParameter.Optional },
                new { controller = "LoginSV|SVHome" },
                 new[] { "WebQuanLyHocTap.Areas.SinhViens.Controllers" }
            );
        }
    }
}