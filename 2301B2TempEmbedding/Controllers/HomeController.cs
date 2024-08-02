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

                return View(ItemDetail);
            }
            else
            {
                return RedirectToAction("Products");
            }
        }
        public IActionResult AddToCart(string qty , string UserId , string ItemId , string price) 
        {

            var cartdata = new Cart
            {
                UserId = Convert.ToInt32(UserId),
                ItemId = Convert.ToInt32(ItemId),
                Price = Convert.ToInt32(price),
                Qty = Convert.ToInt32(qty),
                Total = Convert.ToInt32(qty) * Convert.ToInt32(price)
            };

            db.Carts.Add(cartdata);
            db.SaveChanges();
            return RedirectToAction("Products");        
        }
    }
}