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
            var list = c.Transactions
     .Where(x => x.IsLocked == false)
     .GroupBy(x => x.SerialNumber) // SerialNumber'a göre grupla
     .Select(g => g.FirstOrDefault()) // Her gruptan ilk elemanı seç
     .ToList();

            return View(list);
        }


            public ActionResult AddBilling(string serialnumber) 
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
            //var billingget = c.Billings.Find(serialnumber);
            var billing = c.Transactions.FirstOrDefault(x => x.SerialNumber == serialnumber);

            var currentname = billing.Current.CurrentName;
            ViewBag.CurrentName = currentname;
            var date = billing.Date;
            ViewBag.Date = date;

            var serialnumbervalue = c.Transactions.Where(x => x.SerialNumber == serialnumber);

            var amount=serialnumbervalue.Sum(x => x.Amount);
            ViewBag.Amount = amount;

            var totalprice = serialnumbervalue.Sum(x => x.TotalPrice);
            ViewBag.TotalPrice = totalprice;

            var unitprice = serialnumbervalue.Sum(x => x.Price);
                ViewBag.UnitPrice = unitprice;

            //var product = billing.Product.ProductName;
            //ViewBag.Product = product;
            //var price= billing.Price.ToString().Replace(".","");
            //ViewBag.Price = price;
            //var amount= billing.Amount;
            //ViewBag.Amount = amount;

            //var totalprice = billing.TotalPrice.ToString().Replace(".", "");
            //ViewBag.TotalPrice = totalprice;

            var trans = billing.SerialNumber.ToString();
            ViewBag.Trans = trans;


            //decimal Prrice = billing.Price; // Örnek olarak billing değişkeninden Price özelliğini alıyoruz.
            //string formattedPrice = Prrice.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR")); // Para birimi formatına çeviriyoruz.
            //ViewBag.FormattedPrice = formattedPrice;

            //decimal TotalPrice = billing.TotalPrice;
            //string formattedTotalPrice = TotalPrice.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("tr-TR"));
            //ViewBag.FormattedTotalPrice = formattedTotalPrice;
            var personel = billing.Employee.FirstName + " " + billing.Employee.LastName;
            ViewBag.Personel = personel;
            var personelid = billing.Employeeid;
            ViewBag.Employeeid = personelid;
            var currentid = billing.Currentid;
            ViewBag.CurrentId = currentid;



            return View("AddBilling");
        }

        public PartialViewResult BillingDetailPartial(string SerialNumber)
        {
            var detail = c.Transactions.Where(x => x.SerialNumber == SerialNumber).ToList();
            return PartialView(detail);
        }

        public ActionResult Deneme(string SerialNumber)
        {
            var detail = c.Transactions.Where(x => x.SerialNumber == SerialNumber).ToList();
            return View(detail);
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
        public ActionResult BillingDetail(string SerialNumber)
        {
            var values = c.Billings.Where(x => x.SerialNumber == SerialNumber).ToList();
            var billing = c.Billings.FirstOrDefault(x => x.SerialNumber == SerialNumber);

            var currentname = billing.Current.CurrentName;
            ViewBag.CurrentName = currentname;
            var date = billing.Date.ToString("dd.MM.yyyy");
            ViewBag.Date = date;
            var time = billing.Time.ToString();
            ViewBag.Time = time;
            var serial = billing.SerialNumber.ToString();
            ViewBag.Serial = serial;
            var desc = billing.Description.ToString();
            ViewBag.Description = desc;
            var emp = billing.Employee.FirstName + " " + billing.Employee.LastName;
            ViewBag.Employer = emp;
            var tax = billing.TaxOffice.ToString();
            ViewBag.Tax = tax;




            //var billingdetail = c.Billings.Where(x => x.TransacationSerialNumber == TransacationSerialNumber).ToList();
            //var description = billingdetail.D
            //ViewBag.description = description;
            //var serialnumber = billingdetail.SerialNumber.ToString();
            //ViewBag.serialnumber = serialnumber;
            //var current = billingdetail.Current.CurrentName.ToString();
            //ViewBag.current = current;
            //var date = billingdetail.Date.ToString("dd.MM.yyyy");
            //ViewBag.date = date;
            //var time = billingdetail.Time.ToString();
            //ViewBag.time = time;
            //var tax = billingdetail.TaxOffice.ToString();
            //ViewBag.tax = tax;
            //var Employee = billingdetail.Employee.FirstName + " " + billingdetail.Employee.LastName;
            //ViewBag.employee = Employee;

            return View("BillingDetail");
        }
    }
}