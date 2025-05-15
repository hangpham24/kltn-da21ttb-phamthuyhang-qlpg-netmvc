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
    public class HuanLuyenViensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HuanLuyenViensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HuanLuyenViens
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HuanLuyenViens.Include(h => h.TaiKhoan);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HuanLuyenViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huanLuyenVien = await _context.HuanLuyenViens
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.MaPT == id);
            if (huanLuyenVien == null)
            {
                return NotFound();
            }

            return View(huanLuyenVien);
        }

        // GET: HuanLuyenViens/Create
        public IActionResult Create()
        {
            ViewData["MaTK"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash");
            return View();
        }

        // POST: HuanLuyenViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPT,MaTK,HoTen,NgaySinh,GioiTinh,SoDienThoai,Email,ChuyenMon,KinhNghiem,DiaChi,TrangThaiHLV")] HuanLuyenVien huanLuyenVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(huanLuyenVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaTK"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", huanLuyenVien.MaTK);
            return View(huanLuyenVien);
        }

        // GET: HuanLuyenViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huanLuyenVien = await _context.HuanLuyenViens.FindAsync(id);
            if (huanLuyenVien == null)
            {
                return NotFound();
            }
            ViewData["MaTK"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", huanLuyenVien.MaTK);
            return View(huanLuyenVien);
        }

        // POST: HuanLuyenViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPT,MaTK,HoTen,NgaySinh,GioiTinh,SoDienThoai,Email,ChuyenMon,KinhNghiem,DiaChi,TrangThaiHLV")] HuanLuyenVien huanLuyenVien)
        {
            if (id != huanLuyenVien.MaPT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(huanLuyenVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HuanLuyenVienExists(huanLuyenVien.MaPT))
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
            ViewData["MaTK"] = new SelectList(_context.TaiKhoans, "MaTK", "MatKhauHash", huanLuyenVien.MaTK);
            return View(huanLuyenVien);
        }

        // GET: HuanLuyenViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var huanLuyenVien = await _context.HuanLuyenViens
                .Include(h => h.TaiKhoan)
                .FirstOrDefaultAsync(m => m.MaPT == id);
            if (huanLuyenVien == null)
            {
                return NotFound();
            }

            return View(huanLuyenVien);
        }

        // POST: HuanLuyenViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var huanLuyenVien = await _context.HuanLuyenViens.FindAsync(id);
            if (huanLuyenVien != null)
            {
                _context.HuanLuyenViens.Remove(huanLuyenVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HuanLuyenVienExists(int id)
        {
            return _context.HuanLuyenViens.Any(e => e.MaPT == id);
        }
    }
}
