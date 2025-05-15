using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class PT_LopHoc
    {
        [Key]
        public int MaPT_LopHoc { get; set; }
        
        [ForeignKey("HuanLuyenVien")]
        [Display(Name = "Huấn luyện viên")]
        public int MaPT { get; set; }

        [ForeignKey("LopHoc")]
        [Display(Name = "Lớp học")]
        public int MaLopHoc { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [Display(Name = "Phần trăm hoa hồng")]
        public decimal PhanTramHoaHong { get; set; }

        // Navigation properties
        public virtual HuanLuyenVien? HuanLuyenVien { get; set; }
        public virtual LopHoc? LopHoc { get; set; }
    }
} 