using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class BangLuongPT
    {
        [Key]
        public int MaLuong { get; set; }

        [Required]
        [ForeignKey("HuanLuyenVien")]
        [Display(Name = "Huấn luyện viên")]
        public int MaPT { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Tháng năm")]
        public DateTime ThangNam { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tổng doanh thu")]
        public decimal TongDoanhThu { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tổng hoa hồng")]
        public decimal TongHoaHong { get; set; } = 0;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Lương cơ bản")]
        public decimal LuongCoBan { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tổng thanh toán")]
        public decimal TongThanhToan { get; set; } = 0;

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "ChuaThanhToan";

        [Display(Name = "Ngày thanh toán")]
        [DataType(DataType.Date)]
        public DateTime? NgayThanhToan { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Navigation properties
        public virtual HuanLuyenVien? HuanLuyenVien { get; set; }
        public virtual ICollection<PhienDay>? PhienDaysTrongKyLuong { get; set; }
    }
}
