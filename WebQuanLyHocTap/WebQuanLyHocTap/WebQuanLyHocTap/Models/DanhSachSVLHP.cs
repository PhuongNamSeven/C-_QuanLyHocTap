namespace WebQuanLyHocTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachSVLHP")]
    public partial class DanhSachSVLHP
    {
        [Key]
        public double diemTk1 { get; set; }

        public double? diemTk2 { get; set; }

        public double? giuaKy { get; set; }

        public double? cuoiKy { get; set; }

        public int? LopHPID { get; set; }

        public int? SinhVienID { get; set; }
    }
}
