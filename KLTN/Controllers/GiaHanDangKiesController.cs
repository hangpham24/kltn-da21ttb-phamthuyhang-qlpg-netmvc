using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KLTN.Data;
using KLTN.Models.Database;

namespace KLTN.Controllers
{
    public class GiaHanDangKiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GiaHanDangKiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GiaHanDangKies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GiaHanDangKys.Include(g => g.DangKy).Include(g => g.NguoiThu);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GiaHanDangKies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaHanDangKy = await _context.GiaHanDangKys
                .Include(g => g.DangKy)
                .Include(g => g.NguoiThu)
                .FirstOrDefaultAsync(m => m.MaGiaHan == id);
            if (giaHanDangKy == null)
            {
                return NotFound();
            }

            return View(giaHanDangKy);
        }

        // GET: GiaHanDangKies/Create
        public IActionResult Create()
        {
            ViewData["MaDangKy"] = new SelectList(_context.DangKys, "MaDangKy", "LoaiDangKy");
            ViewData["MaTKNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash");
            return View();
        }

        // POST: GiaHanDangKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGiaHan,MaDangKy,NgayKetThucMoi,SoBuoiThem,SoTien,NgayGiaHan,MaTKNguoiThu,TrangThai,GhiChu")] GiaHanDangKy giaHanDangKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaHanDangKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDangKy"] = new SelectList(_context.DangKys, "MaDangKy", "LoaiDangKy", giaHanDangKy.MaDangKy);
            ViewData["MaTKNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", giaHanDangKy.MaTKNguoiThu);
            return View(giaHanDangKy);
        }

        // GET: GiaHanDangKies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaHanDangKy = await _context.GiaHanDangKys.FindAsync(id);
            if (giaHanDangKy == null)
            {
                return NotFound();
            }
            ViewData["MaDangKy"] = new SelectList(_context.DangKys, "MaDangKy", "LoaiDangKy", giaHanDangKy.MaDangKy);
            ViewData["MaTKNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", giaHanDangKy.MaTKNguoiThu);
            return View(giaHanDangKy);
        }

        // POST: GiaHanDangKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGiaHan,MaDangKy,NgayKetThucMoi,SoBuoiThem,SoTien,NgayGiaHan,MaTKNguoiThu,TrangThai,GhiChu")] GiaHanDangKy giaHanDangKy)
        {
            if (id != giaHanDangKy.MaGiaHan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaHanDangKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaHanDangKyExists(giaHanDangKy.MaGiaHan))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDangKy"] = new SelectList(_context.DangKys, "MaDangKy", "LoaiDangKy", giaHanDangKy.MaDangKy);
            ViewData["MaTKNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", giaHanDangKy.MaTKNguoiThu);
            return View(giaHanDangKy);
        }

        // GET: GiaHanDangKies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaHanDangKy = await _context.GiaHanDangKys
                .Include(g => g.DangKy)
                .Include(g => g.NguoiThu)
                .FirstOrDefaultAsync(m => m.MaGiaHan == id);
            if (giaHanDangKy == null)
            {
                return NotFound();
            }

            return View(giaHanDangKy);
        }

        // POST: GiaHanDangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giaHanDangKy = await _context.GiaHanDangKys.FindAsync(id);
            if (giaHanDangKy != null)
            {
                _context.GiaHanDangKys.Remove(giaHanDangKy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaHanDangKyExists(int id)
        {
            return _context.GiaHanDangKys.Any(e => e.MaGiaHan == id);
        }
    }
}
