using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyDaoTao.Data;
using QuanLyDaoTao.Models;

namespace QuanLyDaoTao.Controllers
{
    public class LopHocPhansController : Controller
    {
        private readonly AppDbContext _context;

        public LopHocPhansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LopHocPhans
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.LopHocPhans.Include(l => l.GiangVien).Include(l => l.KhoaHoc);
            return View(await appDbContext.ToListAsync());
        }

        // GET: LopHocPhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.GiangVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Create
        public IActionResult Create()
        {
            ViewData["GiangVienId"] = new SelectList(_context.GiangViens, "Id", "HoTen");
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "Id", "TenKhoaHoc");
            return View();
        }

        // POST: LopHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaLop,KhoaHocId,GiangVienId")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiangVienId"] = new SelectList(_context.GiangViens, "Id", "HoTen", lopHocPhan.GiangVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "Id", "TenKhoaHoc", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["GiangVienId"] = new SelectList(_context.GiangViens, "Id", "HoTen", lopHocPhan.GiangVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "Id", "TenKhoaHoc", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaLop,KhoaHocId,GiangVienId")] LopHocPhan lopHocPhan)
        {
            if (id != lopHocPhan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.Id))
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
            ViewData["GiangVienId"] = new SelectList(_context.GiangViens, "Id", "HoTen", lopHocPhan.GiangVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.KhoaHocs, "Id", "TenKhoaHoc", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.LopHocPhans
                .Include(l => l.GiangVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);
            if (lopHocPhan != null)
            {
                _context.LopHocPhans.Remove(lopHocPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(int id)
        {
            return _context.LopHocPhans.Any(e => e.Id == id);
        }
    }
}
