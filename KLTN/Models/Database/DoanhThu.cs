using KLTN.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class DoanhThu
    {
        [Key]
        public int MaThu { get; set; }

        [ForeignKey("ThanhToan")]
        [Display(Name = "Thanh toán")]
        public int? MaThanhToan { get; set; }

        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int? MaTV { get; set; }

        [ForeignKey("KhachVangLai")]
        [Display(Name = "Khách vãng lai")]
        public int? MaKVL { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Số tiền")]
        public decimal SoTien { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày thu")]
        public DateTime NgayThu { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        [Display(Name = "Loại thu")]
        public string LoaiThu { get; set; } = string.Empty;

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "DaXacNhan";

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        [ForeignKey("NguoiThu")]
        [Display(Name = "Người thu")]
        public int? MaNguoiThu { get; set; }

        // Navigation properties
        public virtual ThanhToan? ThanhToan { get; set; }
        public virtual ThanhVien? ThanhVien { get; set; }
        public virtual KhachVangLai? KhachVangLai { get; set; }
        public virtual TaiKhoan? NguoiThu { get; set; }
    }
}
