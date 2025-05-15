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
    public class DoanhThusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoanhThusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DoanhThus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DoanhThus.Include(d => d.KhachVangLai).Include(d => d.NguoiThu).Include(d => d.ThanhToan).Include(d => d.ThanhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DoanhThus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhThu = await _context.DoanhThus
                .Include(d => d.KhachVangLai)
                .Include(d => d.NguoiThu)
                .Include(d => d.ThanhToan)
                .Include(d => d.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaThu == id);
            if (doanhThu == null)
            {
                return NotFound();
            }

            return View(doanhThu);
        }

        // GET: DoanhThus/Create
        public IActionResult Create()
        {
            ViewData["MaKVL"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL");
            ViewData["MaNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash");
            ViewData["MaThanhToan"] = new SelectList(_context.ThanhToans, "MaThanhToan", "LoaiThanhToan");
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV");
            return View();
        }

        // POST: DoanhThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaThu,MaThanhToan,MaTV,MaKVL,SoTien,NoiDung,NgayThu,LoaiThu,TrangThai,GhiChu,MaNguoiThu")] DoanhThu doanhThu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doanhThu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKVL"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", doanhThu.MaKVL);
            ViewData["MaNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", doanhThu.MaNguoiThu);
            ViewData["MaThanhToan"] = new SelectList(_context.ThanhToans, "MaThanhToan", "LoaiThanhToan", doanhThu.MaThanhToan);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", doanhThu.MaTV);
            return View(doanhThu);
        }

        // GET: DoanhThus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhThu = await _context.DoanhThus.FindAsync(id);
            if (doanhThu == null)
            {
                return NotFound();
            }
            ViewData["MaKVL"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", doanhThu.MaKVL);
            ViewData["MaNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", doanhThu.MaNguoiThu);
            ViewData["MaThanhToan"] = new SelectList(_context.ThanhToans, "MaThanhToan", "LoaiThanhToan", doanhThu.MaThanhToan);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", doanhThu.MaTV);
            return View(doanhThu);
        }

        // POST: DoanhThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaThu,MaThanhToan,MaTV,MaKVL,SoTien,NoiDung,NgayThu,LoaiThu,TrangThai,GhiChu,MaNguoiThu")] DoanhThu doanhThu)
        {
            if (id != doanhThu.MaThu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doanhThu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoanhThuExists(doanhThu.MaThu))
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
            ViewData["MaKVL"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", doanhThu.MaKVL);
            ViewData["MaNguoiThu"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", doanhThu.MaNguoiThu);
            ViewData["MaThanhToan"] = new SelectList(_context.ThanhToans, "MaThanhToan", "LoaiThanhToan", doanhThu.MaThanhToan);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", doanhThu.MaTV);
            return View(doanhThu);
        }

        // GET: DoanhThus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doanhThu = await _context.DoanhThus
                .Include(d => d.KhachVangLai)
                .Include(d => d.NguoiThu)
                .Include(d => d.ThanhToan)
                .Include(d => d.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaThu == id);
            if (doanhThu == null)
            {
                return NotFound();
            }

            return View(doanhThu);
        }

        // POST: DoanhThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doanhThu = await _context.DoanhThus.FindAsync(id);
            if (doanhThu != null)
            {
                _context.DoanhThus.Remove(doanhThu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoanhThuExists(int id)
        {
            return _context.DoanhThus.Any(e => e.MaThu == id);
        }
    }
}
