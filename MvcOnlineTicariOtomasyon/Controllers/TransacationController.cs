using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class TransacationController : Controller
    {
        // GET: Transacation
        Context c = new Context();
        public ActionResult Index()
        {
            var values=c.Transactions.ToList();
            return View(values);
        }
        public ActionResult AddTransacation()
        {
            List<SelectListItem> value1 = (from x in c.Currents.Where(x => x.IsActive==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CurrentName,
                                               Value = x.CurrentId.ToString()
                                           }).ToList();
            ViewBag.Current = value1;
            List<SelectListItem>value2= (from x in c.Products
                                         where x.IsActive == true && x.StokAmount > 0
                                         select new SelectListItem
                                         {
                                             Text = x.ProductName,
                                            Value= x.ProductId.ToString()
                                        }
                                        ).ToList();
            ViewBag.Product = value2;
            List<SelectListItem> value3 = (from x in c.Employees.Where(x=>x.Department.DepartmentId==1).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FirstName + ' '+ x.LastName,
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

        [HttpPost] 
        public ActionResult AddTransacation(Transaction p)
        {
            c.Transactions.Add(p);
           
            c.SaveChanges();
            return RedirectToAction("Index");
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
           trn.Currentid=p.Currentid;
            trn.TotalPrice = p.TotalPrice;
            trn.Productid = p.Productid;
            trn.Amount = p.Amount;
            trn.Price = p.Price;
            trn.Currentid= p.Currentid;
            trn.Date= p.Date;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PdfTransacation()
        {
            var values = c.Transactions.ToList();
            return View(values);
        }
    }
}