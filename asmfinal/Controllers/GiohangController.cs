using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asmfinal.Models;

namespace asmfinal.Controllers
{
    public class GiohangController : Controller
    {
        private readonly ASMContext _context;

        public GiohangController(ASMContext context)
        {
            _context = context;
        }

        // GET: Giohang
        [HttpGet("/manage/giohang")]
        public async Task<IActionResult> Index()
        {
            var aSMContext = _context.Giohang.Include(g => g.MaHangNavigation).Include(g => g.MaKhachNavigation);
            return View(await aSMContext.ToListAsync());
        }

        // GET: Giohang/Details/5
        [HttpGet("/manage/Giohang/Details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang
                .Include(g => g.MaHangNavigation)
                .Include(g => g.MaKhachNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // GET: Giohang/Create
        [HttpGet("/manage/Giohang/Create")]
        public IActionResult Create()
        {
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang");
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi");
            return View();
        }

        // POST: Giohang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/manage/Giohang/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,SoLuong,MaKhach")] Giohang giohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", giohang.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", giohang.MaKhach);
            return View(giohang);
        }

        // GET: Giohang/Edit/5
        [HttpGet("/manage/Giohang/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang.FindAsync(id);
            if (giohang == null)
            {
                return NotFound();
            }
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", giohang.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", giohang.MaKhach);
            return View(giohang);
        }

        // POST: Giohang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Giohang/Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHang,SoLuong,MaKhach")] Giohang giohang)
        {
            if (id != giohang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiohangExists(giohang.MaHang))
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
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", giohang.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", giohang.MaKhach);
            return View(giohang);
        }

        // GET: Giohang/Delete/5
        [HttpGet("/manage/Giohang/Detele/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giohang = await _context.Giohang
                .Include(g => g.MaHangNavigation)
                .Include(g => g.MaKhachNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (giohang == null)
            {
                return NotFound();
            }

            return View(giohang);
        }

        // POST: Giohang/Delete/5

        [HttpPost("/manage/Giohang/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giohang = await _context.Giohang.FindAsync(id);
            _context.Giohang.Remove(giohang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiohangExists(int id)
        {
            return _context.Giohang.Any(e => e.MaHang == id);
        }
    }
}
