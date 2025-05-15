using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class BaoCaoTaiChinh
    {
        [Key]
        public int MaBaoCao { get; set; }

        [Required]
        [Range(1, 12)]
        [Display(Name = "Tháng")]
        public int Thang { get; set; }

        [Required]
        [Range(2000, 2100)]
        [Display(Name = "Năm")]
        public int Nam { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Tổng doanh thu")]
        public decimal TongDoanhThu { get; set; } = 0;

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày lập báo cáo")]
        public DateTime NgayLapBaoCao { get; set; } = DateTime.Now;

        [ForeignKey("TaiKhoan")]
        [Display(Name = "Người lập")]
        public int? NguoiLap { get; set; }

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "ChuaDuyet";

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Navigation properties
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}
