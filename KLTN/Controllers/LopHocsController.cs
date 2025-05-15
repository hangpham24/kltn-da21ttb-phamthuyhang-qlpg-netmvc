using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KLTN.Data;
using KLTN.Models.Database;
using KLTN.Models.ViewModels;

namespace KLTN.Controllers
{
    public class LopHocsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHocs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LopHoc.Include(l => l.HuanLuyenVien);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LopHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .Include(l => l.HuanLuyenVien)
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // GET: LopHocs/Create
        public IActionResult Create()
        {
            var huanLuyenViens = _context.HuanLuyenViens.ToList();
            if (huanLuyenViens != null && huanLuyenViens.Any())
            {
                ViewBag.MaPT = new SelectList(huanLuyenViens, "MaPT", "HoTen");
            }
            else
            {
                ViewBag.MaPT = new SelectList(new List<SelectListItem>());
            }
            return View(new LopHocViewModel());
        }

        // POST: LopHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLop,TenLop,MaPT,ThoiGianBatDau,ThoiGianKetThuc,SelectedDays,SoLuongToiDa,SoLuongHienTai,TrangThai,GhiChu")] LopHocViewModel lopHocVM)
        {
            if (ModelState.IsValid)
            {
                var lopHoc = lopHocVM.ToLopHoc();
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            var huanLuyenViens = _context.HuanLuyenViens.ToList();
            if (huanLuyenViens != null && huanLuyenViens.Any())
            {
                ViewBag.MaPT = new SelectList(huanLuyenViens, "MaPT", "HoTen", lopHocVM.MaPT);
            }
            else
            {
                ViewBag.MaPT = new SelectList(new List<SelectListItem>());
            }
            return View(lopHocVM);
        }

        // GET: LopHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            
            var lopHocVM = LopHocViewModel.FromLopHoc(lopHoc);
            
            var huanLuyenViens = _context.HuanLuyenViens.ToList();
            if (huanLuyenViens != null && huanLuyenViens.Any())
            {
                ViewBag.MaPT = new SelectList(huanLuyenViens, "MaPT", "HoTen", lopHoc.MaPT);
            }
            else
            {
                ViewBag.MaPT = new SelectList(new List<SelectListItem>());
            }
            return View(lopHocVM);
        }

        // POST: LopHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLop,TenLop,MaPT,ThoiGianBatDau,ThoiGianKetThuc,SelectedDays,SoLuongToiDa,SoLuongHienTai,TrangThai,GhiChu")] LopHocViewModel lopHocVM)
        {
            if (id != lopHocVM.MaLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lopHoc = lopHocVM.ToLopHoc();
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHocVM.MaLop))
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
            
            var huanLuyenViens = _context.HuanLuyenViens.ToList();
            if (huanLuyenViens != null && huanLuyenViens.Any())
            {
                ViewBag.MaPT = new SelectList(huanLuyenViens, "MaPT", "HoTen", lopHocVM.MaPT);
            }
            else
            {
                ViewBag.MaPT = new SelectList(new List<SelectListItem>());
            }
            return View(lopHocVM);
        }

        // GET: LopHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHoc
                .Include(l => l.HuanLuyenVien)
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // POST: LopHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHoc = await _context.LopHoc.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHoc.Remove(lopHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(int id)
        {
            return _context.LopHoc.Any(e => e.MaLop == id);
        }
    }
}
