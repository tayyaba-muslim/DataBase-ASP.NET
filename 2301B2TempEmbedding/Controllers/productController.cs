using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class productController : Controller
    {
        EcommerceContext db = new EcommerceContext();
        public IActionResult Index()
        {
            return View(db.Tables.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Table tab)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Add(tab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
