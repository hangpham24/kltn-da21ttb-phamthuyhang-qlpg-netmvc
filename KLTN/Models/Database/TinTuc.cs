using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KLTN.Models;
using Microsoft.AspNetCore.Http;

namespace KLTN.Models.Database
{
    public class TinTuc
    {
        [Key]
        public int MaTinTuc { get; set; }

        [NotMapped]
        public int Id { get { return MaTinTuc; } }

        [Required]
        [StringLength(200)]
        [Display(Name = "Tiêu đề")]
        public string TieuDe { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui l�ng nh?p m� t? ng?n")]
        [StringLength(500)]
        [Display(Name = "M� t? ng?n")]
        public string MoTaNgan { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; } = string.Empty;

        [StringLength(255)]
        [Display(Name = "Hình ảnh URL")]
        public string? HinhAnhURL { get; set; }

        [NotMapped]
        [Display(Name = "File h�nh ?nh")]
        public IFormFile? HinhAnhFile { get; set; }

        [Required(ErrorMessage = "Vui l�ng nh?p danh m?c")]
        [StringLength(100)]
        [Display(Name = "Danh m?c")]
        public string DanhMuc { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "T�c gi? (hi?n th?)")]
        public string? TacGiaDisplay { get; set; }

        [ForeignKey("TaiKhoan")]
        [Display(Name = "Người đăng")]
        public int? NguoiDang { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày đăng")]
        public DateTime NgayDang { get; set; } = DateTime.Now;

        [Display(Name = "Th?i gian d?c (pht)")]
        public int? ThoiGianDoc { get; set; }

        [Display(Name = "Lu?t xem")]
        public int LuotXem { get; set; } = 0;

        [Display(Name = "Hi?n th?")]
        public bool HienThi { get; set; } = true;

        [Display(Name = "Tin n?i b?t")]
        public bool NoiBat { get; set; } = false;

        [StringLength(20)]
        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "HoatDong";

        // Navigation properties
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}
