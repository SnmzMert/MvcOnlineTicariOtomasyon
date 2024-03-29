using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var items = c.Products.Where(x => x.IsActive == true).ToList();
            return View(items);
        }
        public ActionResult AddProduct()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.Category = value1;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            c.Products.Add(product);
            product.IsActive = true;
            c.SaveChanges();
           
            return RedirectToAction("Index");
        }

        public ActionResult RemoveProduct(int id)
        {
            var prod = c.Products.Find(id);
            prod.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int id)
        {
            {
                List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
                ViewBag.Category = value1;
                var product = c.Products.Find(id);
                return View("GetProduct", product);
            }
        }

        public ActionResult UpdateProduct(Product p )
        {
            var prod = c.Products.Find(p.ProductId);
            prod.ProductName = p.ProductName;
            prod.PurchasePrice = p.PurchasePrice;
            prod.SalePrice = p.SalePrice;   
            prod.Brand = p.Brand;
            prod.ProductImage = p.ProductImage;
            prod.CategoryId = p.CategoryId;
            prod.StokAmount = p.StokAmount;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}