using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using asmfinal.Models;
using Microsoft.AspNetCore.Http;
using System.Web.Providers.Entities;
using Microsoft.Extensions.Logging;
namespace asmfinal.Controllers
{
    [Route("/account/[action]")]
    public class AccountController : Controller
    {
       [Route("/account")]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction("Index", controllerName: "Home");
            }
            return View();
        }
        private readonly ASMContext context;
         public AccountController(ASMContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult signup()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction(nameof(InfoUser));
            }
            return View();
        }
        [TempData]
        public string message { get; set; }
        [HttpPost]
        public async Task<IActionResult> signup(Khachhang Khachhang)
        {
           
                
                Khachhang user = new Khachhang { TenKhach = Khachhang.TenKhach, Email = Khachhang.Email, MatKhau = Khachhang.MatKhau, DiaChi = Khachhang.DiaChi , SoDienThoai = Khachhang.SoDienThoai,
                    GioiTinh = Khachhang.GioiTinh , NgaySinh = Khachhang.NgaySinh
                };
                var a = await context.AddAsync(user);
                var b = await context.SaveChangesAsync();
            TempData["message"] = "Đăng ký thành công";
              
                return RedirectToAction("Index");

        }
       [HttpGet]
       public IActionResult signin()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction(nameof(InfoUser));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> signin(Khachhang Khachhang)
        {
            var iUser = await context.Khachhang.FirstOrDefaultAsync(x => x.Email == Khachhang.Email && x.MatKhau == Khachhang.MatKhau);
             if(iUser  == null)
            {
                TempData["message"] = "Email hoặc mật khẩu không đúng";
                TempData["messageType"] = "danger";
                return RedirectToAction("Index");

            }
            else
            {
                HttpContext.Session.SetString("tenkhach", iUser.TenKhach);
                HttpContext.Session.SetString("emailuser", iUser.Email);
                return RedirectToAction("Index", controllerName: "Home");

            }

        }

        [HttpPost]
        public async Task<IActionResult> signinAdmin(Nhanvien Nhanvien)
        {
            Console.WriteLine(Nhanvien.Email);
            Console.WriteLine(Nhanvien.MatKhau);

            var iUser = await context.Nhanvien.FirstOrDefaultAsync(x => x.Email == Nhanvien.Email && x.MatKhau == Nhanvien.MatKhau);
            if (iUser == null)
            {
                TempData["message"] = "Email hoặc mật khẩu không đúng";
                TempData["messageType"] = "danger";
                return RedirectToAction("Admin");

            }
            else
            {
                HttpContext.Session.SetString("tenNv", iUser.TenNv);
                HttpContext.Session.SetString("emailNv", iUser.Email);
                return RedirectToAction(nameof(Index) , controllerName: "SanPham");
            }

        }
        [HttpGet]
        public IActionResult InfoUser()
        {
            ViewBag.nameuser = HttpContext.Session.GetString("tenkhach");
            ViewBag.emailuser = HttpContext.Session.GetString("emailuser");

            return View();
        }
        public IActionResult Logout()
        {
            TempData.Clear();
            message = "Đăng xuất thành công";
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult logoutAdmin()
        {
            TempData.Clear();
            message = "Đăng xuất thành công";
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Admin));
        }
        public IActionResult Welcome()
        {
            ViewData["Message"] = "Chao mung ban";
            return View();
        }

        [Route("/admin")]

        public IActionResult Admin()
        {
            return View();
        }
    }
}
