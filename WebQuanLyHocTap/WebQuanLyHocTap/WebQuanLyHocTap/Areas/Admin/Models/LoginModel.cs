using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebQuanLyHocTap.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Ban phai nhap UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Ban phai nhap PassWord")]
        public string PassWord { get; set; }
        public bool Remember { get; set; }
    }
}