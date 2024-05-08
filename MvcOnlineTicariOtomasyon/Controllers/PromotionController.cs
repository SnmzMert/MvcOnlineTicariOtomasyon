using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
   
    public class PromotionController : Controller
    {
        Context c = new Context();
        // GET: Promotion
        public ActionResult Index()
        {
            var values = c.Promotions.ToList();
            return View(values);
        }

        
        public ActionResult Create()
        {
            var TransacationList = c.Promotions.ToList();
            int currentYear = DateTime.Now.Year;


            var existingBillings = TransacationList.Where(x => x.EndDate.Year == currentYear);


            int lastBillingNumber = existingBillings.Any() ? existingBillings.Max(x => int.Parse(x.SerialNumber.Substring(x.SerialNumber.IndexOf('-') + 1))) : 0;




            string billingNumber = $"{currentYear}-{(lastBillingNumber + 1).ToString("D3")}";



            ViewBag.BillingNumber = billingNumber;



            List<SelectListItem> value2 = (from x in c.Products
                                           where x.IsActive == true && x.StokAmount > 0
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
        public ActionResult Create(Promotion promotion)
        {
            c.Promotions.Add(promotion);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cat = c.Promotions.Find(id);
            c.Promotions.Remove(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}