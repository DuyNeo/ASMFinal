using asmfinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace asmfinal.Controllers
{
    [Route("/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ASMContext _context;

        public HomeController(ILogger<HomeController> logger, ASMContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/")]
        public async Task<IActionResult> Index(int? id, string name)
        {
         
            ViewData["danhmuc"] = await _context.Danhmuc.ToListAsync();
            if(name != null)
            {
                return View(await _context.Sanpham.Select(x => x).Where(x => x.TenHang.Contains(name)).ToListAsync());
            }
            if (id == null)
            {
                return View(await _context.Sanpham.ToListAsync());

            }
            else
            {
                var danhmucs = await _context.Sanpham.Select(x => x).Where(x => x.MaDm == id).ToListAsync();
                return View(danhmucs);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/contact")]
       
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {

            Sanpham sanpham = await _context.Sanpham
              .FirstOrDefaultAsync(m => m.MaHang == id);
            return View(sanpham);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
