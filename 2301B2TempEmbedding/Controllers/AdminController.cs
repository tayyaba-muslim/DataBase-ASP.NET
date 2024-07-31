using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NuGet.Configuration;

namespace _2301B2TempEmbedding.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
                ViewBag.adminEmail = HttpContext.Session.GetString("adminEmail");
                return View();
           
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Addprod()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Addprod(Product prd)
        {
            if (ModelState.IsValid)
            {
                return Content("data is all good");
            }
            return View();
        }
    }
}
