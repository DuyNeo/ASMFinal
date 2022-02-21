

namespace asmfinal.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using asmfinal.Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Http;

    [Route("/cart/[action]")]
    public class CartController : Controller
    {
        private readonly ASMContext context;

        public CartController(ASMContext context)
        {
            this.context = context;
        }
        [Route("/cart")]
        public IActionResult Index()
        {
            var carts = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart");
            if (carts != null)
            {
                ViewBag.total = carts.Sum(x => x.sanpham.DonGiaBan * x.Quantity);

            }

            return View(carts);

        }

        private int isExist(int? id)
        {
            List<ItemCart> carts = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart");
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].sanpham.MaHang.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        public async Task<IActionResult> Buy(int? id)
        {
            ProductModel model = new ProductModel(context);

            if (SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart") == null)
            {
                List<ItemCart> carts = new List<ItemCart>();
                carts.Add(new ItemCart { sanpham = await model.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);

            }
            else
            {
                List<ItemCart> carts = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if (index != -1)
                {
                    carts[index].Quantity++;
                }
                else
                {
                    carts.Add(new ItemCart { sanpham = await model.Find(id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Remove(int? id)
        {
            List<ItemCart> carts = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart");
            int index = isExist(id);
            carts.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Pay()
        {

            if (HttpContext.Session.GetString("tenkhach") == null)
            {
                TempData["message"] = "Bạn phải đăng nhập trước khi đặt hàng";
                return RedirectToAction("Index", controllerName: "Account");
            }
            var carts = SessionHelper.GetObjectFormJson<List<ItemCart>>(HttpContext.Session, "cart");
            if (carts != null)
            {
                ViewBag.total = carts.Sum(x => x.sanpham.DonGiaBan * x.Quantity);

            }
            return View(carts);
        }
    }
}

