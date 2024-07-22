using _2301B2TempEmbedding.Models;

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

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role") == "user")
            {
                ViewBag.userEmail = HttpContext.Session.GetString("userEmail");
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Admin");
            }
        }

        public IActionResult Products()
        {
            var ItemsData = db.Items.Include(a => a.Cat);

            return View(ItemsData);
        }

        public IActionResult Contact()
        {
            return View();
        }

    }
}