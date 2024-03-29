using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class BilligController : Controller
    {
        // GET: Billig
        Context c=new Context();    
        public ActionResult Index()
        {
            var list = c.Billings.ToList();
            return View(list);
        }
        
       public ActionResult GetBilling()
        {
            var list = c.Transactions.Where(x=>x.IsLocked==false).ToList();
            return View(list); 
        
        }
        
        
        public ActionResult AddBilling(int id) 
        {
            var billingList = c.Billings.ToList();
            int currentYear = DateTime.Now.Year;

            // Geçerli yıla ait olan faturaları filtrele
            var existingBillings = billingList.Where(x => x.Date.Year == currentYear);

            // En son seri numarasını al
            int lastBillingNumber = existingBillings.Any() ? existingBillings.Max(x => int.Parse(x.SerialNumber.Substring(x.SerialNumber.IndexOf('-') + 1))) : 0;



            // Yeni fatura numarasını oluştur
            string billingNumber = $"{currentYear}-{(lastBillingNumber + 1).ToString("D3")}";


            // ViewBag üzerinden fatura numarasını View'a taşı
            ViewBag.BillingNumber = billingNumber;

            // Fatura listesini View'a gönder
            var billingget = c.Billings.Find(id);
            var billing = c.Transactions.Find(id);
            var currentname = billing.Current.CurrentName;
            ViewBag.CurrentName = currentname;
            var date = billing.Date;
            ViewBag.Date = date;
            var product = billing.Product.ProductName;
            ViewBag.Product = product;
            var price= billing.Price.ToString().Replace(".","");
            ViewBag.Price = price;
            var amount= billing.Amount;
            ViewBag.Amount = amount;
            
            var totalprice = billing.TotalPrice.ToString().Replace(".", "");
            ViewBag.TotalPrice = totalprice;

            var trans =billing.Id.ToString();
            ViewBag.Trans = trans;

            decimal Prrice = billing.Price; // Örnek olarak billing değişkeninden Price özelliğini alıyoruz.
            string formattedPrice = Prrice.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR")); // Para birimi formatına çeviriyoruz.
            ViewBag.FormattedPrice = formattedPrice;

            decimal TotalPrice = billing.TotalPrice;
            string formattedTotalPrice = TotalPrice.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
            ViewBag.FormattedTotalPrice = formattedTotalPrice;
            var personel = billing.Employee.FirstName +" " + billing.Employee.LastName;
            ViewBag.Personel = personel;
            var personelid = billing.Employeeid;
              ViewBag.Employeeid = personelid;
            var currentid= billing.Currentid;
            ViewBag.CurrentId = currentid;



            return View("AddBilling", billingget);
        }
        [HttpPost]
        public ActionResult AddBilling(Billing p)
        {
            DateTime currentTime = DateTime.Now;
            string currentTimeString = currentTime.ToString("HH:mm");
            c.Billings.Add(p);
            p.Time = currentTimeString;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BillingDetail(int id)
        {
            var values = c.Billings.Where(x => x.Id == id).ToList();
            return View("BillingDetail", values);
        }
    }
}