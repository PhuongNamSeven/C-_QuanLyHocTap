namespace WebQuanLyHocTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SinhVien")]
    public partial class SinhVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SinhVienID { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250)]
        public string TenSV { get; set; }

        [StringLength(250)]
        public string QueQuan { get; set; }

        public DateTime? NgayDiemDanh { get; set; }
    }
}
