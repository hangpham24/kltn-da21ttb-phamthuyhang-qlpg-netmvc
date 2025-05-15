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
    public class PT_LopHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PT_LopHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PT_LopHoc
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PT_LopHoc.Include(p => p.HuanLuyenVien).Include(p => p.LopHoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PT_LopHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_LopHoc = await _context.PT_LopHoc
                .Include(p => p.HuanLuyenVien)
                .Include(p => p.LopHoc)
                .FirstOrDefaultAsync(m => m.MaPT_LopHoc == id);
            if (pT_LopHoc == null)
            {
                return NotFound();
            }

            return View(pT_LopHoc);
        }

        // GET: PT_LopHoc/Create
        public IActionResult Create()
        {
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT");
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan");
            return View();
        }

        // POST: PT_LopHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPT_LopHoc,MaPT,MaLopHoc,PhanTramHoaHong")] PT_LopHoc pT_LopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pT_LopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_LopHoc.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", pT_LopHoc.MaLopHoc);
            return View(pT_LopHoc);
        }

        // GET: PT_LopHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_LopHoc = await _context.PT_LopHoc.FindAsync(id);
            if (pT_LopHoc == null)
            {
                return NotFound();
            }
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_LopHoc.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", pT_LopHoc.MaLopHoc);
            return View(pT_LopHoc);
        }

        // POST: PT_LopHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPT_LopHoc,MaPT,MaLopHoc,PhanTramHoaHong")] PT_LopHoc pT_LopHoc)
        {
            if (id != pT_LopHoc.MaPT_LopHoc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pT_LopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PT_LopHocExists(pT_LopHoc.MaPT_LopHoc))
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
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_LopHoc.MaPT);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", pT_LopHoc.MaLopHoc);
            return View(pT_LopHoc);
        }

        // GET: PT_LopHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_LopHoc = await _context.PT_LopHoc
                .Include(p => p.HuanLuyenVien)
                .Include(p => p.LopHoc)
                .FirstOrDefaultAsync(m => m.MaPT_LopHoc == id);
            if (pT_LopHoc == null)
            {
                return NotFound();
            }

            return View(pT_LopHoc);
        }

        // POST: PT_LopHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pT_LopHoc = await _context.PT_LopHoc.FindAsync(id);
            if (pT_LopHoc != null)
            {
                _context.PT_LopHoc.Remove(pT_LopHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PT_LopHocExists(int id)
        {
            return _context.PT_LopHoc.Any(e => e.MaPT_LopHoc == id);
        }
    }
}
