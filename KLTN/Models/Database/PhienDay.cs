using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class PhienDay
    {
        [Key]
        public int MaPhienDay { get; set; }

        [ForeignKey("HuanLuyenVien")]
        [Display(Name = "Huấn luyện viên")]
        public int MaPT { get; set; }

        [ForeignKey("LopHoc")]
        [Display(Name = "Lớp học")]
        public int? MaLopHoc { get; set; }

        [ForeignKey("GoiTap")]
        [Display(Name = "Gói tập")]
        public int? MaGoiTap { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày dạy")]
        public DateTime NgayDay { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Giá trị buổi dạy")]
        public decimal GiaTriBuoiDay { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại phiên dạy")]
        public string? LoaiPhienDay { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Loại dịch vụ")]
        public string LoaiDichVu { get; set; } = string.Empty;

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string? TrangThai { get; set; } = "DaHoanThanh";

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        [ForeignKey("BangLuongPT")]
        public int? MaBangLuong { get; set; }

        // Navigation properties
        public virtual HuanLuyenVien? HuanLuyenVien { get; set; }
        public virtual LopHoc? LopHoc { get; set; }
        public virtual GoiTap? GoiTap { get; set; }
        public virtual BangLuongPT? BangLuongPT { get; set; }
    }
}
