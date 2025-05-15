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
    public class PhienDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhienDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhienDays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PhienDays.Include(p => p.BangLuongPT).Include(p => p.GoiTap).Include(p => p.HuanLuyenVien).Include(p => p.LopHoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PhienDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phienDay = await _context.PhienDays
                .Include(p => p.BangLuongPT)
                .Include(p => p.GoiTap)
                .Include(p => p.HuanLuyenVien)
                .Include(p => p.LopHoc)
                .FirstOrDefaultAsync(m => m.MaPhienDay == id);
            if (phienDay == null)
            {
                return NotFound();
            }

            return View(phienDay);
        }

        // GET: PhienDays/Create
        public IActionResult Create()
        {
            ViewData["MaBangLuong"] = new SelectList(_context.BangLuongPTs, "MaLuong", "MaLuong");
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi");
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT");
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan");
            return View();
        }

        // POST: PhienDays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPhienDay,MaPT,MaLopHoc,MaGoiTap,NgayDay,GiaTriBuoiDay,LoaiPhienDay,LoaiDichVu,TrangThai,GhiChu,MaBangLuong")] PhienDay phienDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phienDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaBangLuong"] = new SelectList(_context.BangLuongPTs, "MaLuong", "MaLuong", phienDay.MaBangLuong);
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", phienDay.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", phienDay.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", phienDay.MaLopHoc);
            return View(phienDay);
        }

        // GET: PhienDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phienDay = await _context.PhienDays.FindAsync(id);
            if (phienDay == null)
            {
                return NotFound();
            }
            ViewData["MaBangLuong"] = new SelectList(_context.BangLuongPTs, "MaLuong", "MaLuong", phienDay.MaBangLuong);
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", phienDay.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", phienDay.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", phienDay.MaLopHoc);
            return View(phienDay);
        }

        // POST: PhienDays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPhienDay,MaPT,MaLopHoc,MaGoiTap,NgayDay,GiaTriBuoiDay,LoaiPhienDay,LoaiDichVu,TrangThai,GhiChu,MaBangLuong")] PhienDay phienDay)
        {
            if (id != phienDay.MaPhienDay)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phienDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhienDayExists(phienDay.MaPhienDay))
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
            ViewData["MaBangLuong"] = new SelectList(_context.BangLuongPTs, "MaLuong", "MaLuong", phienDay.MaBangLuong);
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", phienDay.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", phienDay.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", phienDay.MaLopHoc);
            return View(phienDay);
        }

        // GET: PhienDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phienDay = await _context.PhienDays
                .Include(p => p.BangLuongPT)
                .Include(p => p.GoiTap)
                .Include(p => p.HuanLuyenVien)
                .Include(p => p.LopHoc)
                .FirstOrDefaultAsync(m => m.MaPhienDay == id);
            if (phienDay == null)
            {
                return NotFound();
            }

            return View(phienDay);
        }

        // POST: PhienDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phienDay = await _context.PhienDays.FindAsync(id);
            if (phienDay != null)
            {
                _context.PhienDays.Remove(phienDay);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhienDayExists(int id)
        {
            return _context.PhienDays.Any(e => e.MaPhienDay == id);
        }
    }
}
