namespace WebQuanLyHocTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonHoc")]
    public partial class MonHoc
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MonHocID { get; set; }

        [StringLength(250)]
        public string TenMonHoc { get; set; }

        public bool isLock { get; set; }
    }
}
