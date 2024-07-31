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

    }
}