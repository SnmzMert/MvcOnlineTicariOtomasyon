using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class TransacationController : Controller
    {

        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Transactions.ToList();
            return View(values);
        }
        public ActionResult AddTransacation()
        {
            var TransacationList = c.Transactions.ToList();
            int currentYear = DateTime.Now.Year;


            var existingBillings = TransacationList.Where(x => x.Date.Year == currentYear);


            int lastBillingNumber = existingBillings.Any() ? existingBillings.Max(x => int.Parse(x.SerialNumber.Substring(x.SerialNumber.IndexOf('-') + 1))) : 0;




            string billingNumber = $"{currentYear}-{(lastBillingNumber + 1).ToString("D3")}";



            ViewBag.BillingNumber = billingNumber;

            ViewBag.CurrentUser = 1;


            List<SelectListItem> value1 = (from x in c.Currents.Where(x => x.IsActive == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.Current = value1;
            List<SelectListItem> value2 = (from x in c.Products
                                           where x.IsActive == true && x.StokAmount > 0
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Product = value2;
            List<SelectListItem> value3 = (from x in c.Employees.Where(x => x.Department.DepartmentId == 1).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FirstName + ' ' + x.LastName,
                                               Value = x.EmployeeId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Employee = value3;
            return View();
        }

        public ActionResult GetProductPrice(int productId)
        {
            var product = c.Products.FirstOrDefault(x => x.ProductId == productId);
            if (product != null)
            {
                return Json(new { price = product.SalePrice }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { price = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCurrentAmount(int currentId)
        {
            var current = c.Currents.FirstOrDefault(x => x.CurrentId == currentId);
            if (current != null)
            {
                return Json(new { amount = current.CurrentAmount }, JsonRequestBehavior.AllowGet);


            }
            else
            {
                return Json(new { amount = 0 }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetPromotoion(int promotionId)
        {
            var promotion = c.Promotions.FirstOrDefault(x => x.PromotionId == promotionId);
            if (promotion != null)
            {
                return Json(new
                {
                    promotionname = promotion.PromotionName,
                    promotionproductid = promotion.Product.ProductId,
                    promotionproductname = promotion.Product.ProductName,
                    endDate = promotion.EndDate.ToString("dd.MMM.yyyy"),
                    promotionpoint = promotion.PromotionPoint
                }, JsonRequestBehavior.AllowGet) ;
            }
            else
            {
                return Json(new { promotion = "null" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetPoint(int productId )
        {
            var promotion = c.ProductPoints.FirstOrDefault(x => x.Productid == productId);
            if (promotion != null)
            {
                return Json(new
                {
                    point = promotion.ProdductPoint,
                   
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { promotion = "null" }, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult AddTransacation(List<Transaction> transactions)
        {
            if (transactions != null)
            {
                foreach (var transaction in transactions)
                {
                    c.Transactions.Add(transaction);
                }
                c.SaveChanges();
                return Json(new { success = true, redirectTo = Url.Action("Index", "Transaction") });
            }
            return Json(new { success = false }); // hata durumunda başarısızlık bilgisini JSON olarak döndür
        }



        public ActionResult GetTransacation(int id)
        {
            List<SelectListItem> value1 = (from x in c.Currents.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.Current = value1;
            List<SelectListItem> value2 = (from x in c.Products.ToList()

                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Product = value2;
            List<SelectListItem> value3 = (from x in c.Employees.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FirstName + ' ' + x.LastName,
                                               Value = x.EmployeeId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Employee = value3;

            var transacation = c.Transactions.Find(id);
            return View(transacation);
        }

        public ActionResult UpdateTransacation(Transaction p)
        {
            var trn = c.Transactions.Find(p.Id);
            trn.Currentid = p.Currentid;
            trn.TotalPrice = p.TotalPrice;
            trn.Productid = p.Productid;
            trn.Amount = p.Amount;
            trn.Price = p.Price;
            trn.Currentid = p.Currentid;
            trn.Date = p.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PdfTransacation()
        {
            var values = c.Transactions.ToList();
            return View(values);
        }

        public ActionResult PromotionTransacation()
        {
            var TransacationList = c.Transactions.ToList();
            int currentYear = DateTime.Now.Year;


            var existingBillings = TransacationList.Where(x => x.Date.Year == currentYear);


            int lastBillingNumber = existingBillings.Any() ? existingBillings.Max(x => int.Parse(x.SerialNumber.Substring(x.SerialNumber.IndexOf('-') + 1))) : 0;




            string billingNumber = $"{currentYear}-{(lastBillingNumber + 1).ToString("D3")}";



            ViewBag.BillingNumber = billingNumber;

            ViewBag.CurrentUser = @Session["userName"];


            List<SelectListItem> value1 = (from x in c.Currents.Where(x => x.IsActive == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.Current = value1;
            List<SelectListItem> value2 = (from x in c.Products
                                           where x.IsActive == true && x.StokAmount > 0
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Product = value2;
            List<SelectListItem> value3 = (from x in c.Promotions.Where(x => x.EndDate >= DateTime.Today).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PromotionName,
                                               Value = x.PromotionId.ToString()
                                           }
                                        ).ToList();
            ViewBag.Promotion = value3;
            return View();
        }
    }
}