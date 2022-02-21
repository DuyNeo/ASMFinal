using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using asmfinal.Models;
using Microsoft.AspNetCore.Http;

namespace Asm123.Controllers
{
    public class KhachhangController : Controller
    {
        private readonly ASMContext _context;

        public KhachhangController(ASMContext context)
        {
            _context = context;
        }

        // GET: Khachhang
        [HttpGet("/manage/khachhang")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("tenNv") == null)
            {
                TempData["message"] = "Vui lòng đăng nhập tài khoản admin";
                return RedirectToAction("Admin", controllerName: "Account");
            }
            return View(await _context.Khachhang.ToListAsync());
        }

        // GET: Khachhang/Details/5
        [HttpGet("/manage/Khachhang/Details/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // GET: Khachhang/Create
        [HttpGet("/manage/Khachhang/Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khachhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/manage/Khachhang/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaKhach,TenKhach,GioiTinh,DiaChi,SoDienThoai,NgaySinh,MatKhau,Email")] Khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khachhang);
        }

        // GET: Khachhang/Edit/5
        [HttpGet("/manage/Khachhang/Edit/{id?}")]
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang.FindAsync(id);
            if (khachhang == null)
            {
                return NotFound();
            }
            return View(khachhang);
        }

        // POST: Khachhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Khachhang/Edit/{id?}")]
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaKhach,TenKhach,GioiTinh,DiaChi,SoDienThoai,NgaySinh,MatKhau,Email")] Khachhang khachhang)
        {
            if (id != khachhang.MaKhach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachhangExists(khachhang.MaKhach))
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
            return View(khachhang);
        }

        // GET: Khachhang/Delete/5
        [HttpGet("/manage/Khachhang/Detele/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachhang = await _context.Khachhang
                .FirstOrDefaultAsync(m => m.MaKhach == id);
            if (khachhang == null)
            {
                return NotFound();
            }

            return View(khachhang);
        }

        // POST: Khachhang/Delete/5
        [HttpPost("/manage/Khachhang/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachhang = await _context.Khachhang.FindAsync(id);
            _context.Khachhang.Remove(khachhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachhangExists(int id)
        {
            return _context.Khachhang.Any(e => e.MaKhach == id);
        }
    }
}
