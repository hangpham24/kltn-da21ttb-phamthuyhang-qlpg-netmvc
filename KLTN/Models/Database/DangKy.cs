using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class DangKy
    {
        [Key]
        public int MaDangKy { get; set; }

        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int MaTV { get; set; }

        [ForeignKey("KhachVangLai")]
        [Display(Name = "Khách vãng lai")]
        public int? MaKhachVangLai { get; set; }

        [ForeignKey("GoiTap")]
        [Display(Name = "Gói tập")]
        public int? MaGoiTap { get; set; }

        [ForeignKey("LopHoc")]
        [Display(Name = "Lớp học")]
        public int? MaLopHoc { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày bắt đầu")]
        public DateTime NgayBatDau { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Loại đăng ký")]
        public string LoaiDangKy { get; set; } = "GoiTap"; // GoiTap, LopHoc

        [Display(Name = "Số buổi")]
        public int? SoBuoi { get; set; }

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string? TrangThai { get; set; } = "ConHieuLuc"; // ConHieuLuc, HetHan, DaHuy

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày đăng ký")]
        public DateTime NgayDangKy { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual ThanhVien? ThanhVien { get; set; }
        public virtual KhachVangLai? KhachVangLai { get; set; }
        public virtual GoiTap? GoiTap { get; set; }
        public virtual LopHoc? LopHoc { get; set; }
        public virtual ICollection<GiaHanDangKy>? GiaHanDangKys { get; set; }
        public virtual ICollection<ThanhToan>? ThanhToans { get; set; }
    }
} 
