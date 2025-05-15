﻿using System;
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
    public class DichVusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DichVusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DichVus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DichVus.Include(d => d.GoiTap).Include(d => d.LopHoc);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DichVus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVus
                .Include(d => d.GoiTap)
                .Include(d => d.LopHoc)
                .FirstOrDefaultAsync(m => m.MaDichVu == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu);
        }

        // GET: DichVus/Create
        public IActionResult Create()
        {
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi");
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan");
            return View();
        }

        // POST: DichVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDichVu,TenDichVu,MoTa,LoaiDichVu,GiaBatDau,HinhAnhURL,MaGoiTap,MaLopHoc")] DichVu dichVu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dichVu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dichVu.MaGoiTap);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dichVu.MaLopHoc);
            return View(dichVu);
        }

        // GET: DichVus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVus.FindAsync(id);
            if (dichVu == null)
            {
                return NotFound();
            }
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dichVu.MaGoiTap);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dichVu.MaLopHoc);
            return View(dichVu);
        }

        // POST: DichVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDichVu,TenDichVu,MoTa,LoaiDichVu,GiaBatDau,HinhAnhURL,MaGoiTap,MaLopHoc")] DichVu dichVu)
        {
            if (id != dichVu.MaDichVu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dichVu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DichVuExists(dichVu.MaDichVu))
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
            ViewData["MaGoiTap"] = new SelectList(_context.GoiTap, "MaGoi", "TenGoi", dichVu.MaGoiTap);
            ViewData["MaLopHoc"] = new SelectList(_context.LopHoc, "MaLop", "NgayTrongTuan", dichVu.MaLopHoc);
            return View(dichVu);
        }

        // GET: DichVus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dichVu = await _context.DichVus
                .Include(d => d.GoiTap)
                .Include(d => d.LopHoc)
                .FirstOrDefaultAsync(m => m.MaDichVu == id);
            if (dichVu == null)
            {
                return NotFound();
            }

            return View(dichVu);
        }

        // POST: DichVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dichVu = await _context.DichVus.FindAsync(id);
            if (dichVu != null)
            {
                _context.DichVus.Remove(dichVu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DichVuExists(int id)
        {
            return _context.DichVus.Any(e => e.MaDichVu == id);
        }
    }
}
