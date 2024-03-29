using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        Context c = new Context();

        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.Values1 = values1;
            var values2=c.Products.Where(x=>x.IsActive==true).Count().ToString(); 
            ViewBag.Values2 = values2;
            // Tüm ürünlerin satış fiyatlarını ve maliyet fiyatlarını çek
            var products = c.Products.ToList();
            decimal totalSalesPrice = 0;
            decimal totalCostPrice = 0;

            foreach (var product in products)
            {
                totalSalesPrice += product.SalePrice;
                totalCostPrice += product.PurchasePrice;
            }

            // Satış fiyatlarının toplamını maliyet fiyatlarının toplamına böler ve yüzdeyi hesaplar
            decimal fark = totalSalesPrice - totalCostPrice  ;
            decimal percentage = fark  / totalCostPrice * 100;



            // Yüzde değerini ViewBag'e ekle, ondalık kısmı kaldırarak yuvarla
            ViewBag.percentage = Math.Round(percentage, 0);

            var todo=c.ToDos.Where(x=>x.Status==true).ToList();
            return View(todo);
        } 
    }
}
