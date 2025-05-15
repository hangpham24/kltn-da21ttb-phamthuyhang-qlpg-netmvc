using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class PT_GoiTap
    {
        [Key]
        public int MaPT_GoiTap { get; set; }
        
        [ForeignKey("HuanLuyenVien")]
        [Display(Name = "Huấn luyện viên")]
        public int MaPT { get; set; }

        [ForeignKey("GoiTap")]
        [Display(Name = "Gói tập")]
        public int MaGoiTap { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Phần trăm hoa hồng")]
        public decimal PhanTramHoaHong { get; set; }

        // Navigation properties
        public virtual HuanLuyenVien? HuanLuyenVien { get; set; }
        public virtual GoiTap? GoiTap { get; set; }
    }
} 