namespace WebTruyenChu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [Key]
        public int makh { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(20)]
        public string tendangnhap { get; set; }

        [StringLength(10)]
        public string matkhau { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(100)]
        public string diachi { get; set; }

        [StringLength(15)]
        public string dienthoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ngaysinh { get; set; }
    }
}
