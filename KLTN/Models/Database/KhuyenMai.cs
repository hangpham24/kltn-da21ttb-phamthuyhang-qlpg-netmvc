using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class KhuyenMai
    {
        [Key]
        public int MaKM { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tên khuyến mãi")]
        public string TenKM { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Phần trăm giảm")]
        public int PhanTramGiam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string? TrangThai { get; set; } = "DangApDung";

        // Thm cc di?u ki?n �p d?ng khuy?n m�i
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Gi� tr? don h�ng t?i thi?u")]
        public decimal? GiaTriToiThieu { get; set; }

        [Display(Name = "Gi?m t?i da")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal? GiamToiDa { get; set; }

        [StringLength(50)]
        [Display(Name = "M� khuy?n m�i (n?u c�)")]
        public string? MaKhuyenMai { get; set; }

        [Display(Name = "S? lu?ng m� t?i da")]
        public int? SoLuongMaToiDa { get; set; }

        [Display(Name = "�� s? d?ng")]
        public int? SoLuongDaSuDung { get; set; } = 0;

        [StringLength(50)]
        [Display(Name = "�?i tu?ng �p d?ng")]
        public string? DoiTuongApDung { get; set; } = "TatCa"; // TatCa, ThanhVienMoi, ThanhVienCu, VIP

        [Display(Name = "Ng�y t?o")]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ICollection<GoiTap>? GoiTaps { get; set; }
    }
}
