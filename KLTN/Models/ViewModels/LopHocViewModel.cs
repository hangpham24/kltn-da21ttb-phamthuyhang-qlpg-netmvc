using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KLTN.Models.Database;

namespace KLTN.Models.ViewModels
{
    public class LopHocViewModel
    {
        public int MaLop { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên lớp")]
        [StringLength(100)]
        [Display(Name = "Tên lớp")]
        public string TenLop { get; set; } = string.Empty;

        [Display(Name = "Huấn luyện viên")]
        public int? MaPT { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thời gian bắt đầu")]
        [DataType(DataType.Time)]
        [Display(Name = "Thời gian bắt đầu")]
        public TimeSpan ThoiGianBatDau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thời gian kết thúc")]
        [DataType(DataType.Time)]
        [Display(Name = "Thời gian kết thúc")]
        public TimeSpan ThoiGianKetThuc { get; set; }

        [Display(Name = "Ngày trong tuần")]
        public string NgayTrongTuan { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn ít nhất một ngày trong tuần")]
        [Display(Name = "Ngày trong tuần")]
        public List<string> SelectedDays { get; set; } = new List<string>();

        [Required(ErrorMessage = "Vui lòng nhập số lượng tối đa")]
        [Display(Name = "Số lượng tối đa")]
        public int SoLuongToiDa { get; set; }

        [Display(Name = "Số lượng hiện tại")]
        public int SoLuongHienTai { get; set; } = 0;

        [Display(Name = "Trạng thái")]
        public string TrangThai { get; set; } = "DangMo";

        [StringLength(500)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Danh sách các ngày trong tuần
        public static List<string> DaysOfWeek = new List<string>
        {
            "Thứ Hai",
            "Thứ Ba",
            "Thứ Tư",
            "Thứ Năm",
            "Thứ Sáu",
            "Thứ Bảy",
            "Chủ Nhật"
        };

        // Chuyển từ view model sang model
        public LopHoc ToLopHoc()
        {
            return new LopHoc
            {
                MaLop = this.MaLop,
                TenLop = this.TenLop,
                MaPT = this.MaPT,
                ThoiGianBatDau = this.ThoiGianBatDau,
                ThoiGianKetThuc = this.ThoiGianKetThuc,
                NgayTrongTuan = string.Join(", ", this.SelectedDays),
                SoLuongToiDa = this.SoLuongToiDa,
                SoLuongHienTai = this.SoLuongHienTai,
                TrangThai = this.TrangThai,
                GhiChu = this.GhiChu
            };
        }

        // Chuyển từ model sang view model
        public static LopHocViewModel FromLopHoc(LopHoc lopHoc)
        {
            return new LopHocViewModel
            {
                MaLop = lopHoc.MaLop,
                TenLop = lopHoc.TenLop,
                MaPT = lopHoc.MaPT,
                ThoiGianBatDau = lopHoc.ThoiGianBatDau,
                ThoiGianKetThuc = lopHoc.ThoiGianKetThuc,
                NgayTrongTuan = lopHoc.NgayTrongTuan,
                SelectedDays = string.IsNullOrEmpty(lopHoc.NgayTrongTuan) 
                    ? new List<string>() 
                    : new List<string>(lopHoc.NgayTrongTuan.Split(", ")),
                SoLuongToiDa = lopHoc.SoLuongToiDa,
                SoLuongHienTai = lopHoc.SoLuongHienTai,
                TrangThai = lopHoc.TrangThai,
                GhiChu = lopHoc.GhiChu
            };
        }
    }
} 