using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2301B2TempEmbedding.Controllers
{

    public class HomeController : Controller
    {
        private readonly EcommerceContext db;
        public HomeController(EcommerceContext _db)
        {
            this.db = _db;
        }
        [Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Products()
        {
            var ItemsData = db.Items.Include(a => a.Cat);

            return View(ItemsData);
        }
        [Authorize(Roles = "User")]
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var ItemsData = db.Items.Include(a => a.Cat);
            var ItemDetail = ItemsData.FirstOrDefault(b => b.Id == id);
            if (ItemDetail != null)
            {
                Cart cart = new Cart();
                ViewBag.Cart = cart;
                return View(ItemDetail);
            }
            else
            {
                return RedirectToAction("Products");
            }
        }
        [HttpPost]
        public IActionResult AddToCart(Cart cart)
        {
            var checkDuplicate = db.Carts.Where(X => X.ItemId == cart.ItemId).ToList();

            if (checkDuplicate.Any() && checkDuplicate != null)
            {
                checkDuplicate[0].Qty += cart.Qty;

                checkDuplicate[0].Total += cart.Price * cart.Qty;
                db.Carts.Update(checkDuplicate[0]);
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                cart.Total = cart.Price * cart.Qty;
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Products");
            }

            //var cartdata = new Cart
            //{
            //    UserId = Convert.ToInt32(UserId),
            //    ItemId = Convert.ToInt32(ItemId),
            //    Price = Convert.ToInt32(price),
            //    Qty = Convert.ToInt32(qty),
            //    Total = Convert.ToInt32(qty) * Convert.ToInt32(price)
            //};
            cart.Total = cart.Price * cart.Qty;

            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        public IActionResult Cart()
        {
            return View();
        }
    }

    }
