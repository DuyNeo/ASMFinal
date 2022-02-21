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
    [Route("account/[action]")]
    public class AccountController : Controller
    {
       [Route("/account")]
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction(nameof(InfoUser));
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
        public async Task<IActionResult> signup(Login login)
        {
            if (ModelState.IsValid)
            {
                Login user = new Login { name = login.name, email = login.email, password = login.password };
                var a = await context.AddAsync(user);
                var b = await context.SaveChangesAsync();
                message = "DAng ki thanh cong";
                return RedirectToAction(nameof(Index));
            }
            return View(login);
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
        public async Task<IActionResult> signin(Login login)
        {
            var iUser = await context.Khachhang.FirstOrDefaultAsync(x => x.Email == login.email && x.MatKhau == login.password);
             if(iUser  == null)
            {
                ViewData["thongbao"] = "email hoac mat khau kh dung";
                return View(login);

            }
            else
            {
                HttpContext.Session.SetString("tenkhach", iUser.TenKhach);
                HttpContext.Session.SetString("emailuser", iUser.Email);
                return RedirectToAction(nameof(InfoUser));
            }
        
        }
        [HttpGet]
        public IActionResult InfoUser()
        {
            ViewBag.nameuser = HttpContext.Session.GetString("tenkhach");
            ViewBag.emailuser = HttpContext.Session.GetString("emailuser");

            return View();
        }
        public IActionResult Login()
        {
            TempData.Clear();
            message = "dang xuat thanh cong";
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Welcome()
        {
            ViewData["Message"] = "Chao mung ban";
            return View();
        }
    }
}
