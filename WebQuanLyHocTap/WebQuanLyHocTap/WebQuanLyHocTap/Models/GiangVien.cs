namespace WebQuanLyHocTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GiangVien")]
    public partial class GiangVien
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GiangVienID { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string PassWord { get; set; }

        [StringLength(250)]
        public string TenGV { get; set; }
    }
}
