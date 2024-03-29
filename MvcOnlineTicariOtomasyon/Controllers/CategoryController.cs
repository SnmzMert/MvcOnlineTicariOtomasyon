using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Categori
        Context c = new Context();
        public ActionResult Index()
        {
            var items = c.Categories.ToList();
            return View(items);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            c.Categories.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveCategory(int id)
        {
            var cat = c.Categories.Find(id);
            c.Categories.Remove(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateCategory(int id)
        {
            
            var cat = c.Categories.Find(id);
            return View("UpdateCategory",cat);
        }

        public ActionResult CategoryUpdate  (Category category)
        {
            var cat = c.Categories.Find(category.CategoryId);
            cat.CategoryName=category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}