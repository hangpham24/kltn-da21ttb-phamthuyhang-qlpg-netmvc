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
    public class PT_GoiTapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PT_GoiTapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PT_GoiTap
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PT_GoiTap.Include(p => p.GoiTap).Include(p => p.HuanLuyenVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PT_GoiTap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_GoiTap = await _context.PT_GoiTap
                .Include(p => p.GoiTap)
                .Include(p => p.HuanLuyenVien)
                .FirstOrDefaultAsync(m => m.MaPT_GoiTap == id);
            if (pT_GoiTap == null)
            {
                return NotFound();
            }

            return View(pT_GoiTap);
        }

        // GET: PT_GoiTap/Create
        public IActionResult Create()
        {
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi");
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT");
            return View();
        }

        // POST: PT_GoiTap/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaPT_GoiTap,MaPT,MaGoiTap,PhanTramHoaHong")] PT_GoiTap pT_GoiTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pT_GoiTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", pT_GoiTap.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_GoiTap.MaPT);
            return View(pT_GoiTap);
        }

        // GET: PT_GoiTap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_GoiTap = await _context.PT_GoiTap.FindAsync(id);
            if (pT_GoiTap == null)
            {
                return NotFound();
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", pT_GoiTap.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_GoiTap.MaPT);
            return View(pT_GoiTap);
        }

        // POST: PT_GoiTap/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaPT_GoiTap,MaPT,MaGoiTap,PhanTramHoaHong")] PT_GoiTap pT_GoiTap)
        {
            if (id != pT_GoiTap.MaPT_GoiTap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pT_GoiTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PT_GoiTapExists(pT_GoiTap.MaPT_GoiTap))
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
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", pT_GoiTap.MaGoiTap);
            ViewData["MaPT"] = new SelectList(_context.HuanLuyenViens, "MaPT", "MaPT", pT_GoiTap.MaPT);
            return View(pT_GoiTap);
        }

        // GET: PT_GoiTap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pT_GoiTap = await _context.PT_GoiTap
                .Include(p => p.GoiTap)
                .Include(p => p.HuanLuyenVien)
                .FirstOrDefaultAsync(m => m.MaPT_GoiTap == id);
            if (pT_GoiTap == null)
            {
                return NotFound();
            }

            return View(pT_GoiTap);
        }

        // POST: PT_GoiTap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pT_GoiTap = await _context.PT_GoiTap.FindAsync(id);
            if (pT_GoiTap != null)
            {
                _context.PT_GoiTap.Remove(pT_GoiTap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PT_GoiTapExists(int id)
        {
            return _context.PT_GoiTap.Any(e => e.MaPT_GoiTap == id);
        }
    }
}
