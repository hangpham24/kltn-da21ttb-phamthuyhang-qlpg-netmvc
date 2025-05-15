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
    public class GoiTapsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoiTapsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GoiTaps
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GoiTap.Include(g => g.KhuyenMai);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GoiTaps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap
                .Include(g => g.KhuyenMai)
                .FirstOrDefaultAsync(m => m.MaGoi == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // GET: GoiTaps/Create
        public IActionResult Create()
        {
            ViewData["MaKM"] = new SelectList(_context.KhuyenMais, "MaKM", "TenKM");
            return View();
        }

        // POST: GoiTaps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaGoi,TenGoi,MoTa,ThoiHanThang,GiaTien,SoLanTapToiDa,MaKM")] GoiTap goiTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goiTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaKM"] = new SelectList(_context.KhuyenMais, "MaKM", "TenKM", goiTap.MaKM);
            return View(goiTap);
        }

        // GET: GoiTaps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap.FindAsync(id);
            if (goiTap == null)
            {
                return NotFound();
            }
            ViewData["MaKM"] = new SelectList(_context.KhuyenMais, "MaKM", "TenKM", goiTap.MaKM);
            return View(goiTap);
        }

        // POST: GoiTaps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaGoi,TenGoi,MoTa,ThoiHanThang,GiaTien,SoLanTapToiDa,MaKM")] GoiTap goiTap)
        {
            if (id != goiTap.MaGoi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goiTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoiTapExists(goiTap.MaGoi))
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
            ViewData["MaKM"] = new SelectList(_context.KhuyenMais, "MaKM", "TenKM", goiTap.MaKM);
            return View(goiTap);
        }

        // GET: GoiTaps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTap
                .Include(g => g.KhuyenMai)
                .FirstOrDefaultAsync(m => m.MaGoi == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // POST: GoiTaps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goiTap = await _context.GoiTap.FindAsync(id);
            if (goiTap != null)
            {
                _context.GoiTap.Remove(goiTap);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoiTapExists(int id)
        {
            return _context.GoiTap.Any(e => e.MaGoi == id);
        }
    }
}
