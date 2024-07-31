using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2301B2TempEmbedding.Controllers
{
    public class productController : Controller
    {
        private readonly EcommerceContext db;
        public productController(EcommerceContext _db)
        {
            this.db = _db;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(db.Tables.ToList());
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var table = db.Tables.Find(id);
            return View(table);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Table tab)
        {
            if (ModelState.IsValid)
            {
                db.Tables.Update(tab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var table = db.Tables.Find(id);
            return View(table);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Table tab)
        {
            
                db.Tables.Remove(tab);
                db.SaveChanges();
                return RedirectToAction("Index");
            

        }
    }
}
