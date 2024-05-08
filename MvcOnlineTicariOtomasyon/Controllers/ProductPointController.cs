using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductPointController : Controller
    {
        // GET: ProductPoint
        Context c = new Context();
        public ActionResult Index()
        {
            var values =c.ProductPoints.ToList();

            return View(values);
        }
        
        public ActionResult Create()
        {
            List<SelectListItem> value2 = (from x in c.Products.Where(x=>x.IsActive==true).ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }
                                       ).ToList();
            ViewBag.Product = value2;

            return View();

        }

        [HttpPost]
        public ActionResult Create(ProductPoint productPoint)
        {
            c.ProductPoints.Add(productPoint);
            c.SaveChanges();
        return RedirectToAction("Index");
        }


        public ActionResult Delete  (int id)
        {
            var prod = c.ProductPoints.Find(id);
            c.ProductPoints.Remove(prod);

            c.SaveChanges();
            return RedirectToAction("Index");
        }    

        public ActionResult Detail (int id)
        {
            var prod = c.ProductPoints.Find(id);

            return View(prod);
        }
        
        
    }
}