using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyHocTap.Common
{
    [Serializable]
    public class SinhVienLogin
    {
        public long SinhVienID { get; set; }
        public string UserName { get; set; }
    }
}