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
    public class DangKiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DangKiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DangKies
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DangKys.Include(d => d.GoiTap).Include(d => d.KhachVangLai).Include(d => d.LopHoc).Include(d => d.ThanhVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DangKies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys
                .Include(d => d.GoiTap)
                .Include(d => d.KhachVangLai)
                .Include(d => d.LopHoc)
                .Include(d => d.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (dangKy == null)
            {
                return NotFound();
            }

            return View(dangKy);
        }

        // GET: DangKies/Create
        public IActionResult Create()
        {
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi");
            ViewData["MaKhachVangLai"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL");
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan");
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV");
            return View();
        }

        // POST: DangKies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDangKy,MaTV,MaKhachVangLai,MaGoiTap,MaLopHoc,NgayBatDau,NgayKetThuc,LoaiDangKy,SoBuoi,TrangThai,GhiChu,NgayDangKy")] DangKy dangKy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dangKy.MaGoiTap);
            ViewData["MaKhachVangLai"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", dangKy.MaKhachVangLai);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dangKy.MaLopHoc);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", dangKy.MaTV);
            return View(dangKy);
        }

        // GET: DangKies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys.FindAsync(id);
            if (dangKy == null)
            {
                return NotFound();
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dangKy.MaGoiTap);
            ViewData["MaKhachVangLai"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", dangKy.MaKhachVangLai);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dangKy.MaLopHoc);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", dangKy.MaTV);
            return View(dangKy);
        }

        // POST: DangKies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDangKy,MaTV,MaKhachVangLai,MaGoiTap,MaLopHoc,NgayBatDau,NgayKetThuc,LoaiDangKy,SoBuoi,TrangThai,GhiChu,NgayDangKy")] DangKy dangKy)
        {
            if (id != dangKy.MaDangKy)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyExists(dangKy.MaDangKy))
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
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dangKy.MaGoiTap);
            ViewData["MaKhachVangLai"] = new SelectList(_context.KhachVangLais, "MaKVL", "MaKVL", dangKy.MaKhachVangLai);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dangKy.MaLopHoc);
            ViewData["MaTV"] = new SelectList(_context.ThanhViens, "MaTV", "MaTV", dangKy.MaTV);
            return View(dangKy);
        }

        // GET: DangKies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKy = await _context.DangKys
                .Include(d => d.GoiTap)
                .Include(d => d.KhachVangLai)
                .Include(d => d.LopHoc)
                .Include(d => d.ThanhVien)
                .FirstOrDefaultAsync(m => m.MaDangKy == id);
            if (dangKy == null)
            {
                return NotFound();
            }

            return View(dangKy);
        }

        // POST: DangKies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dangKy = await _context.DangKys.FindAsync(id);
            if (dangKy != null)
            {
                _context.DangKys.Remove(dangKy);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyExists(int id)
        {
            return _context.DangKys.Any(e => e.MaDangKy == id);
        }
    }
}
