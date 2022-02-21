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
    public class ChitiethoadonController : Controller
    {
        private readonly ASMContext _context;

        public ChitiethoadonController(ASMContext context)
        {
            _context = context;
        }

        // GET: Chitiethoadon
        [HttpGet("/manage/chitiethoadon")]
        public async Task<IActionResult> Index()
        {
            var aSMContext = _context.Chitiethoadon.Include(c => c.MaHangNavigation).Include(c => c.MaKhachNavigation);
            return View(await aSMContext.ToListAsync());
        }

        // GET: Chitiethoadon/Details/5
        [HttpGet("/manage/Chitiethoadon/Details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon
                .Include(c => c.MaHangNavigation)
                .Include(c => c.MaKhachNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Create
        [HttpGet("/manage/Chitiethoadon/Create")]
        public IActionResult Create()
        {
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang");
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi");
            return View();
        }

        // POST: Chitiethoadon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598. 
        [HttpPost("/manage/Chitiethoadon/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhach,MaHang,NgayBan,TongTien")] Chitiethoadon chitiethoadon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitiethoadon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", chitiethoadon.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", chitiethoadon.MaKhach);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Edit/5
        [HttpGet("/manage/Chitiethoadon/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", chitiethoadon.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", chitiethoadon.MaKhach);
            return View(chitiethoadon);
        }

        // POST: Chitiethoadon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Chitiethoadon/Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKhach,MaHang,NgayBan,TongTien")] Chitiethoadon chitiethoadon)
        {
            if (id != chitiethoadon.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitiethoadon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitiethoadonExists(chitiethoadon.MaHang))
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
            ViewData["MaHang"] = new SelectList(_context.Sanpham, "MaHang", "TenHang", chitiethoadon.MaHang);
            ViewData["MaKhach"] = new SelectList(_context.Khachhang, "MaKhach", "DiaChi", chitiethoadon.MaKhach);
            return View(chitiethoadon);
        }

        // GET: Chitiethoadon/Delete/5
        [HttpGet("/manage/Chitiethoadon/Detele/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitiethoadon = await _context.Chitiethoadon
                .Include(c => c.MaHangNavigation)
                .Include(c => c.MaKhachNavigation)
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (chitiethoadon == null)
            {
                return NotFound();
            }

            return View(chitiethoadon);
        }

        // POST: Chitiethoadon/Delete/5
        [HttpPost("/manage/Chitiethoadon/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitiethoadon = await _context.Chitiethoadon.FindAsync(id);
            _context.Chitiethoadon.Remove(chitiethoadon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitiethoadonExists(int id)
        {
            return _context.Chitiethoadon.Any(e => e.MaHang == id);
        }
    }
}
