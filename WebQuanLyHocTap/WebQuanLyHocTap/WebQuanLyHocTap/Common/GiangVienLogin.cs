using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyHocTap.Common
{
    [Serializable]
    public class GiangVienLogin
    {
        public long GiangVienID { get; set; }
        public string UserName { get; set; }
    }
}