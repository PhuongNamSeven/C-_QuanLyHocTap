using System.Web.Mvc;

namespace WebQuanLyHocTap.Areas.GiangViens
{
    public class GiangViensAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GiangViens";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GiangViens_default",
                "GiangViens/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new { controller = "LoginGV|GVHome" },
                 new[] { "WebQuanLyHocTap.Areas.GiangViens.Controllers" }
            );
        }
    }
}