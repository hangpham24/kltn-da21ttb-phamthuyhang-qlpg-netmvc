using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class ThongBao
    {
        [Key]
        public int MaThongBao { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày gửi")]
        public DateTime NgayGui { get; set; } = DateTime.Now;

        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int MaTV { get; set; }

        [Display(Name = "Đã đọc")]
        public bool DaDoc { get; set; } = false;

        // Navigation properties
        public virtual ThanhVien? ThanhVien { get; set; }
    }
}
