using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asmfinal.Models;
using Microsoft.AspNetCore.Http;

namespace asmfinal.Controllers
{
    public class SanphamController : Controller
    {
        private readonly ASMContext _context;

        public SanphamController(ASMContext context)
        {
            _context = context;
        }

        // GET: Sanpham
        [HttpGet("/manage/sanpham")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("tenNv") == null)
            {
                TempData["message"] = "Vui lòng đăng nhập tài khoản admin";
                return RedirectToAction("Admin", controllerName: "Account");
            }
            var aSMContext = _context.Sanpham.Include(s => s.MaDmNavigation);
            return View(await aSMContext.ToListAsync());
        }

        // GET: Sanpham/Details/5
        [HttpGet("/manage/Sanpham/Details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Sanpham/Create
        [HttpGet("/manage/Sanpham/Create")]
        public IActionResult Create()
        {
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm");
            return View();
        }

        // POST: Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/manage/Sanpham/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang,SoLuong,HinhAnh,DonGiaNhap,DonGiaBan,MaDm")] Sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", sanpham.MaDm);
            return View(sanpham);
        }

        // GET: Sanpham/Edit/5
        [HttpGet("/manage/Sanpham/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", sanpham.MaDm);
            return View(sanpham);
        }

        // POST: Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Sanpham/Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHang,TenHang,SoLuong,HinhAnh,DonGiaNhap,DonGiaBan,MaDm")] Sanpham sanpham)
        {
            if (id != sanpham.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.MaHang))
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
            ViewData["MaDm"] = new SelectList(_context.Danhmuc, "MaDm", "TenDm", sanpham.MaDm);
            return View(sanpham);
        }

        // GET: Sanpham/Delete/5
        [HttpGet("/manage/Sanpham/Detele/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanpham
                .Include(s => s.MaDmNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Sanpham/Delete/5
        [HttpPost("/manage/Sanpham/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanpham.FindAsync(id);
            _context.Sanpham.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanpham.Any(e => e.MaHang == id);
        }
    }
}
