using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyHocTap
{
    [Serializable]
    public class AdminLogin
    {
        
        public long AdminID { get; set; }
        public string UserName { get; set; }
    }
}