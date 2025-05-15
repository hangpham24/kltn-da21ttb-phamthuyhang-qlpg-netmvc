using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class Quyen
    {
        [Key]
        public int MaQuyen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên quyền")]
        [StringLength(50)]
        [Display(Name = "Tên quyền")]
        public string TenQuyen { get; set; } = string.Empty; // Values: "Admin", "Huấn luyện viên", "Thành viên"

        [StringLength(255)]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        // Navigation property
        public virtual ICollection<TaiKhoan>? TaiKhoans { get; set; }
    }
}
