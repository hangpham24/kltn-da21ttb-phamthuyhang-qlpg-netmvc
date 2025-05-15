using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class DichVu
    {
        [Key]
        public int MaDichVu { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên dịch vụ")]
        [StringLength(100)]
        [Display(Name = "Tên dịch vụ")]
        public string TenDichVu { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn loại dịch vụ")]
        [StringLength(20)]
        [Display(Name = "Loại dịch vụ")]
        public string LoaiDichVu { get; set; } = "GoiTap"; // GoiTap hoặc LopHoc

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá bắt đầu")]
        public decimal GiaBatDau { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình ảnh URL")]
        public string? HinhAnhURL { get; set; }

        [ForeignKey("GoiTap")]
        [Display(Name = "Gói tập")]
        public int? MaGoiTap { get; set; }

        [ForeignKey("LopHoc")]
        [Display(Name = "Lớp học")]
        public int? MaLopHoc { get; set; }

        // Navigation properties
        public virtual GoiTap? GoiTap { get; set; }
        public virtual LopHoc? LopHoc { get; set; }
    }
}
