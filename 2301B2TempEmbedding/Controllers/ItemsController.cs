using _2301B2TempEmbedding.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _2301B2TempEmbedding.Controllers
{
    public class ItemsController : Controller
    {
        private readonly EcommerceContext db;
        public ItemsController(EcommerceContext _db)
        {
            this.db = _db;
        }
        //index
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var Itemsdata = db.Items.Include(a => a.Cat);
            return View(Itemsdata.ToList());
        }

        //Details
        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
            
            var item2 = db.Items.Find(id);

            return View(item2);
        }
        //Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item, IFormFile file)
        {
            var imageName = DateTime.Now.ToString("yymmddhhmmss");//24074455454454
            imageName += Path.GetFileName(file.FileName);//24074455454454apple.png

            string imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Uploads");
            var imagevalue = Path.Combine(imagepath, imageName);

            using (var stream = new FileStream(imagevalue, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            var dbimage = Path.Combine("/Uploads", imageName);//   /uploads/240715343434apple.png
            item.Image = dbimage;
            if (!ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
            }
            else
            {
                return View();
            }


            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");
            return RedirectToAction("Index");
        }

        //Edit
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");
            var item1 = db.Items.Find(id);

            return View(item1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item, IFormFile file, string oldimage)
        {
            var dbimage = "";

            if (file != null && file.Length > 0)
            {
                var imageName = DateTime.Now.ToString("yymmddhhmmss");//24074455454454
                imageName += Path.GetFileName(file.FileName);//24074455454454apple.png

                string imagepath = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/Uploads");
                var imagevalue = Path.Combine(imagepath, imageName);

                using (var stream = new FileStream(imagevalue, FileMode.Create))
                {

                    file.CopyTo(stream);

                }

                dbimage = Path.Combine("/Uploads", imageName);//   /uploads/240715343434apple.png
                item.Image = dbimage;
                db.Items.Update(item);
                db.SaveChanges();



            }
            else
            {
                item.Image = oldimage;
                db.Items.Update(item);
                db.SaveChanges();

            }

            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var items = db.Items.Find(id);
            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");
            return View(items);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {
            db.Items.Remove(item);
            db.SaveChanges();
            ViewBag.CatId = new SelectList(db.Categories, "CatId", "CatName");
            return RedirectToAction("Index");
        }
    }
}
