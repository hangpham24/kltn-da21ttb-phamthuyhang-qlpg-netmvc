using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KLTN.Models.Database
{
    public class GiaHanDangKy
    {
        [Key]
        public int MaGiaHan { get; set; }

        [Required]
        [ForeignKey("DangKy")]
        [Display(Name = "Mã đăng ký")]
        public int MaDangKy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày kết thúc mới")]
        public DateTime NgayKetThucMoi { get; set; }

        [Display(Name = "Số buổi thêm")]
        public int? SoBuoiThem { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Số tiền")]
        public decimal SoTien { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày gia hạn")]
        public DateTime NgayGiaHan { get; set; } = DateTime.Now;

        [ForeignKey("TaiKhoan")]
        [Display(Name = "Người thu")]
        public int? MaTKNguoiThu { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "DaDong";

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Navigation properties
        public virtual DangKy? DangKy { get; set; }
        public virtual TaiKhoan? TaiKhoan { get; set; }
        public virtual TaiKhoan? NguoiThu { get => TaiKhoan; set => TaiKhoan = value; }
        public virtual ICollection<ThanhToan>? ThanhToans { get; set; }
    }
} 
