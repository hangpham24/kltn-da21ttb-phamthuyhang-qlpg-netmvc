using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class PhienTap
    {
        [Key]
        public int MaPhien { get; set; }

        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int? MaThanhVien { get; set; }

        [ForeignKey("KhachVangLai")]
        [Display(Name = "Khách vãng lai")]
        public int? MaKhachVangLai { get; set; }

        [ForeignKey("HuanLuyenVien")]
        [Display(Name = "Huấn luyện viên")]
        public int? MaPT { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày tập")]
        public DateTime NgayTap { get; set; }

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        [StringLength(50)]
        [Display(Name = "Tình trạng")]
        public string? TinhTrang { get; set; } = "DaHoanThanh";

        // Navigation properties
        public virtual ThanhVien? ThanhVien { get; set; }
        public virtual KhachVangLai? KhachVangLai { get; set; }
        public virtual HuanLuyenVien? HuanLuyenVien { get; set; }
    }
} 