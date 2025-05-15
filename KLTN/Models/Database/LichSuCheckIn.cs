using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http; // Cho IFormFile

namespace KLTN.Models.Database
{
    public class LichSuCheckIn
    {
        [Key]
        public int MaCheckIn { get; set; }

        [ForeignKey("ThanhVien")]
        [Display(Name = "Thành viên")]
        public int? MaTV { get; set; }

        [ForeignKey("KhachVangLai")]
        [Display(Name = "Khách vãng lai")]
        public int? MaKVL { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Thời gian")]
        public DateTime ThoiGian { get; set; } = DateTime.Now;

        [Display(Name = "Kết quả nhận diện")]
        public bool KetQuaNhanDien { get; set; } = true;

        [Display(Name = "Ảnh nhận diện")]
        public byte[]? AnhNhanDien { get; set; }

        // Navigation properties
        public virtual ThanhVien? ThanhVien { get; set; }
        public virtual KhachVangLai? KhachVangLai { get; set; }
    }
}
