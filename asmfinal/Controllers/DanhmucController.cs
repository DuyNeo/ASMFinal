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
    public class DanhmucController : Controller
    {
        private readonly ASMContext _context;

        public DanhmucController(ASMContext context)
        {
            _context = context;
        }
      
        // GET: Danhmuc 
        [HttpGet("/manage/danhmuc")]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("tenNv") == null)
            {
                TempData["message"] = "Vui lòng đăng nhập tài khoản admin";
                return RedirectToAction("Admin", controllerName: "Account");
            }
            return View(await _context.Danhmuc.ToListAsync());
        }
        //GET: Danhmuc/Details/{Id?}
        [HttpGet("/manage/Danhmuc/Details/{Id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // GET: Danhmuc/Create
        [HttpGet("/manage/Danhmuc/Create")]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Danhmuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/manage/Danhmuc/Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDm,TenDm")] Danhmuc danhmuc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(danhmuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        // GET: Danhmuc/Edit/5
        [HttpGet("/manage/Danhmuc/Edit/{id?}")]
        public async Task<IActionResult> Edit(int? id) // nhung74 ham co tham so m sua z {id?}
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        // POST: Danhmuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("manage/Danhmuc/Edit/{id?}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaDm,TenDm")] Danhmuc danhmuc)
        {
            if (id != danhmuc.MaDm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.MaDm))
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
            return View(danhmuc);
        }

        // GET: Danhmuc/Delete/5
        [HttpGet("/manage/Danhmuc/Delete/{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmuc
                .FirstOrDefaultAsync(m => m.MaDm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);                
        }

        // POST: Danhmuc/Delete/5
        [HttpPost("/manage/Danhmuc/Delete/{id?}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmuc = await _context.Danhmuc.FindAsync(id);
            _context.Danhmuc.Remove(danhmuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //cai1 nay khong suaa
        private bool DanhmucExists(int id)
        {
            return _context.Danhmuc.Any(e => e.MaDm == id);
        }
    }
}
