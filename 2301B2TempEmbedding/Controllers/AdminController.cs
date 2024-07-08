using _2301B2TempEmbedding.Models;
using Microsoft.AspNetCore.Mvc;

using NuGet.Configuration;

namespace _2301B2TempEmbedding.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("role")== "admin")
            {
                ViewBag.adminEmail = HttpContext.Session.GetString("adminEmail");
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string pass)
        {
            if(email == "admin@gmail.com" && pass == "123")
            {
                HttpContext.Session.SetString("adminEmail", email);
                HttpContext.Session.SetString("role", "admin");

              return  RedirectToAction("Index");



            }else if (email == "haris@gmail.com" && pass == "123")
            {

                HttpContext.Session.SetString("userEmail", email);
                HttpContext.Session.SetString("role", "user");
                return RedirectToAction("Index","Home");

            }
            else
            {
                ViewBag.msg = "Invalid Credentials";
            return View();
            }
        }
        public IActionResult AddProduct()
        {
            return View();
        }

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


        public IActionResult AdminLogout()
        {
            HttpContext.Session.Remove("role");
            return RedirectToAction("Login");
        }
    }
}
