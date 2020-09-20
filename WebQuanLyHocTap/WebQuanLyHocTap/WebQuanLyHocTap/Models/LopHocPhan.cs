namespace WebQuanLyHocTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LopHocPhan")]
    public partial class LopHocPhan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LopHPID { get; set; }

        public int? MonHocID { get; set; }

        public int? GiangVienID { get; set; }

        public bool? trangthai { get; set; }

        [StringLength(50)]
        public string tenHocPhan { get; set; }
    }
}
