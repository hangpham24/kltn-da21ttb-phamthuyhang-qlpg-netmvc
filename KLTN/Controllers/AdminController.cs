using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KLTN.Models;
using System.Threading.Tasks;
using KLTN.Data;
using KLTN.Models.Database;
using Microsoft.AspNetCore.Authorization;
using KLTN.Models.ViewModels;

namespace KLTN.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            // Tạo viewmodel cho dashboard
            var viewModel = new AdminDashboardViewModel
            {
                TotalMembers = await _context.ThanhViens.CountAsync(),
                TotalTrainers = await _context.HuanLuyenViens.CountAsync(),
                TotalUsers = await _context.TaiKhoans.CountAsync(),
                TotalPackages = await _context.GoiTap.CountAsync(),
                TotalClasses = await _context.LopHoc.CountAsync(),
                TotalRegistrations = await _context.DangKys.CountAsync(),
                RecentRegistrations = await _context.DangKys
                    .Include(d => d.ThanhVien)
                    .Include(d => d.KhachVangLai)
                    .Include(d => d.GoiTap)
                    .Include(d => d.LopHoc)
                    .OrderByDescending(d => d.NgayDangKy)
                    .Take(5)
                    .ToListAsync(),
                TotalRevenue = await _context.ThanhToans.SumAsync(t => t.SoTien)
            };

            return View(viewModel);
        }

        public IActionResult Finance()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Finance(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParam"] = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewData["TypeSortParam"] = sortOrder == "type" ? "type_desc" : "type";
            ViewData["AmountSortParam"] = sortOrder == "amount" ? "amount_desc" : "amount";
            ViewData["StatusSortParam"] = sortOrder == "status" ? "status_desc" : "status";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var query = _context.DoanhThus
                .Include(d => d.ThanhToan)
                    .ThenInclude(t => t.DangKy)
                        .ThenInclude(dk => dk.ThanhVien)
                .Include(d => d.ThanhToan)
                    .ThenInclude(t => t.DangKy)
                        .ThenInclude(dk => dk.KhachVangLai)
                .Include(d => d.ThanhToan)
                    .ThenInclude(t => t.DangKy)
                        .ThenInclude(dk => dk.GoiTap)
                .Include(d => d.ThanhToan)
                    .ThenInclude(t => t.DangKy)
                        .ThenInclude(dk => dk.LopHoc)
                .Include(d => d.NguoiThu)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(d =>
                    (d.ThanhToan.DangKy.ThanhVien != null && d.ThanhToan.DangKy.ThanhVien.HoTen.Contains(searchString)) ||
                    (d.ThanhToan.DangKy.KhachVangLai != null && d.ThanhToan.DangKy.KhachVangLai.HoTen.Contains(searchString)) ||
                    (d.NguoiThu != null && d.NguoiThu.TenDangNhap.Contains(searchString)) ||
                    (d.GhiChu != null && d.GhiChu.Contains(searchString)));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    query = query.OrderByDescending(d => d.NgayThu);
                    break;
                case "type":
                    query = query.OrderBy(d => d.LoaiThu);
                    break;
                case "type_desc":
                    query = query.OrderByDescending(d => d.LoaiThu);
                    break;
                case "amount":
                    query = query.OrderBy(d => d.SoTien);
                    break;
                case "amount_desc":
                    query = query.OrderByDescending(d => d.SoTien);
                    break;
                case "status":
                    query = query.OrderBy(d => d.TrangThai);
                    break;
                case "status_desc":
                    query = query.OrderByDescending(d => d.TrangThai);
                    break;
                default:
                    query = query.OrderBy(d => d.NgayThu);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<DoanhThu>.CreateAsync(query.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // Phương thức GET để hiển thị form chuẩn hóa quyền
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult NormalizeRoles()
        {
            return View();
        }

        // Phương thức POST để thực hiện chuẩn hóa quyền
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> NormalizeRoles(bool confirm = true)
        {
            try
            {
                // Tìm tất cả quyền trong cơ sở dữ liệu
                var allRoles = await _context.Quyens.ToListAsync();
                
                // Tìm quyền "ThanhVien" và "Thành viên"
                var thanhVienRole = allRoles.FirstOrDefault(r => r.TenQuyen == "ThanhVien");
                var thanhVienSpaceRole = allRoles.FirstOrDefault(r => r.TenQuyen == "Thành viên");
                
                // Tìm quyền "HuanLuyenVien" và "Huấn luyện viên"
                var huanLuyenVienRole = allRoles.FirstOrDefault(r => r.TenQuyen == "HuanLuyenVien");
                var huanLuyenVienSpaceRole = allRoles.FirstOrDefault(r => r.TenQuyen == "Huấn luyện viên");
                
                // Nếu cả hai quyền ThanhVien tồn tại, hợp nhất chúng
                if (thanhVienRole != null && thanhVienSpaceRole != null)
                {
                    // Lấy tất cả tài khoản có quyền "ThanhVien"
                    var thanhVienAccounts = await _context.TaiKhoans
                        .Where(t => t.MaQuyen == thanhVienRole.MaQuyen)
                        .ToListAsync();
                    
                    // Cập nhật tất cả tài khoản để sử dụng quyền "Thành viên"
                    foreach (var account in thanhVienAccounts)
                    {
                        account.MaQuyen = thanhVienSpaceRole.MaQuyen;
                    }
                    
                    // Xóa quyền "ThanhVien"
                    _context.Quyens.Remove(thanhVienRole);
                }
                
                // Nếu cả hai quyền HuanLuyenVien tồn tại, hợp nhất chúng
                if (huanLuyenVienRole != null && huanLuyenVienSpaceRole != null)
                {
                    // Lấy tất cả tài khoản có quyền "HuanLuyenVien"
                    var huanLuyenVienAccounts = await _context.TaiKhoans
                        .Where(t => t.MaQuyen == huanLuyenVienRole.MaQuyen)
                        .ToListAsync();
                    
                    // Cập nhật tất cả tài khoản để sử dụng quyền "Huấn luyện viên"
                    foreach (var account in huanLuyenVienAccounts)
                    {
                        account.MaQuyen = huanLuyenVienSpaceRole.MaQuyen;
                    }
                    
                    // Xóa quyền "HuanLuyenVien"
                    _context.Quyens.Remove(huanLuyenVienRole);
                }
                
                await _context.SaveChangesAsync();
                
                TempData["StatusMessage"] = "Dữ liệu quyền đã được chuẩn hóa thành công.";
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", "Admin");
            }
        }
    }
} 