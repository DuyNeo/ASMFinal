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
    public class NhanvienController : Controller
    {
        private readonly ASMContext _context;

        public NhanvienController(ASMContext context)
        {
            _context = context;
        }

        // GET: Nhanvien
        [HttpGet("/manage/nhanvien")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("tenNv") == null)
            {
                TempData["message"] = "Vui lòng đăng nhập tài khoản admin";
                return RedirectToAction("Admin", controllerName: "Account");
            }
            return View(await _context.Nhanvien.ToListAsync());
        }

        // GET: Nhanvien/Details/5
        [HttpGet("/manage/Nhanvien/Details/{id?}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.Email == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // GET: Nhanvien/Create
        [HttpGet("/manage/Nhanvien/Create")]
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Nhanvien/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/manage/Nhanvien/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenNv,Email,MatKhau,SoDienThoai")] Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhanvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhanvien);
        }

        // GET: Nhanvien/Edit/5
        [HttpGet("/manage/Nhanvien/Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien.FindAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        // POST: Nhanvien/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Nhanvien/Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TenNv,Email,MatKhau,SoDienThoai")] Nhanvien nhanvien)
        {
            if (id != nhanvien.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhanvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhanvienExists(nhanvien.Email))
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
            return View(nhanvien);
        }

        // GET: Nhanvien/Delete/5
        [HttpGet("/manage/Nhanvien/Detele/{id?}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhanvien = await _context.Nhanvien
                .FirstOrDefaultAsync(m => m.Email == id);
            if (nhanvien == null)
            {
                return NotFound();
            }

            return View(nhanvien);
        }

        // POST: Nhanvien/Delete/5
        [HttpPost("/manage/Nhanvien/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(id);
            _context.Nhanvien.Remove(nhanvien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhanvienExists(string id)
        {
            return _context.Nhanvien.Any(e => e.Email == id);
        }
    }
}
