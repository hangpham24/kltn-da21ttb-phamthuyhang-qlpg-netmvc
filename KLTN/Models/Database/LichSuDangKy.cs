using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class LichSuDangKy
    {
        [Key]
        public int MaLichSu { get; set; }

        [Required]
        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int MaTV { get; set; }

        [Required]
        [ForeignKey("GoiTap")]
        [Display(Name = "Gói tập")]
        public int MaGoi { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đăng ký")]
        public DateTime NgayDangKy { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "DaDangKy";

        // Navigation properties
        public virtual ThanhVien? ThanhVien { get; set; }
        public virtual GoiTap? GoiTap { get; set; }
    }
} 