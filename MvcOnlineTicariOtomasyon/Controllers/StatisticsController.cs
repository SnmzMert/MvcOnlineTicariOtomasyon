using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.d1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.d2 = value2;
            var value3 = c.Employees.Count().ToString();
            ViewBag.d3 = value3;
            var value4 = c.Categories.Count().ToString();
            ViewBag.d4 = value4;
            var value5 = c.Products.Sum(x => x.StokAmount).ToString();
            ViewBag.d5 = value5;
            var value7 = c.Products.Count(X => X.StokAmount <= 20).ToString();
            ViewBag.d7 = value7;
            var value6 = (from x in c.Products select x.Brand).Distinct().Count().ToString();
            ViewBag.d6 = value6;
            var value8 = (from x in c.Products where x.IsActive orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.d8 = value8;
            var value9 = (from x in c.Products where x.IsActive orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.d9 = value9;
            var value12 = (from x in c.Products where x.IsActive orderby x.Brand descending select x.Brand).FirstOrDefault();
            ViewBag.d12 = value12;
            var value10 = c.Products.Count(x => x.ProductName == "Buzdolabı" && x.StokAmount > 0).ToString();
            ViewBag.d10 = value10;
            var value11 = c.Products.Count(x => x.ProductName == "Laptop" && x.StokAmount > 0).ToString();
            ViewBag.d11 = value11;

            var value14 = c.Transactions.Sum(X => X.TotalPrice).ToString();
            ViewBag.d14 = value14;
            DateTime today = DateTime.Today;
            var value15 = c.Transactions.Count(x => x.Date == today).ToString();
            ViewBag.d15 = value15;
            var value16 = c.Transactions.Where(X => X.Date == today).Sum(y => (decimal?)y.TotalPrice).ToString();
            ViewBag.d16 = value16;
            var value13 = c.Products.Where(u => u.ProductId == (c.Transactions.GroupBy(x => x.Productid).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.ProductName).FirstOrDefault();
            ViewBag.d13 = value13;
           
            
            return View();


        }
        public ActionResult SimpleTable()
        {
           

            return View();

        }
        public PartialViewResult CityCurrent()
        {
            var totalCount = c.Currents.Count(); // Toplam öğe sayısı

            var get = from x in c.Currents
                      group x by x.City into g
                      select new GroupClass
                      {
                          City = g.Key,
                          IntegerValue = g.Count(), // Tam sayı değerini atama
                          DoubleValue = (int)(((double)g.Count() / totalCount) * 100) // Ondalık sayı değerini hesapla ve atama
                      };
            return PartialView(get.ToList());
        }
        public PartialViewResult Partial1()
        {
            var totalCount = c.Employees.Count(); // Toplam öğe sayısı
            var get1 = from x in c.Employees
                      group x by x.Department.DepartmentName into g
                      select new GroupClass2
                      {
                          Departman = g.Key,
                          IntegerValue = g.Count(), // Tam sayı değerini atama
                          DoubleValue = (int)(((double)g.Count() / totalCount) * 100) // Ondalık sayı değerini hesapla ve atama
                      };
           return PartialView(get1.ToList());
        }
        public PartialViewResult Partial2() 
        {
            var totalCount = c.Products.Count(); // Toplam öğe sayısı
            var get1 = from x in c.Products
                       group x by x.Category.CategoryName into g
                       select new GroupClassCategory
                       {
                           Category = g.Key,
                           IntegerValue = g.Count(), // Tam sayı değerini atama
                           DoubleValue = (int)(((double)g.Count() / totalCount) * 100) // Ondalık sayıyı int'e dönüştür                       };
                       };    return PartialView(get1.ToList());
        }
        public PartialViewResult Partial3()
        {
            var get = c.Currents.ToList();
            return PartialView(get);
        }
        public PartialViewResult Partial4()
        {
            var get = c.Products.Where(x => x.IsActive == true).ToList();
            return PartialView(get);
        }
        public PartialViewResult Partial5()
        {
            var totalCount = c.Products.Where(x=>x.IsActive==true).Count(); // Toplam öğe sayısı
            var get1 = from x in c.Products.Where(x=>x.IsActive==true)
                       group x by x.Brand into g
                       select new GroupClassBrand
                       {
                           Brand = g.Key,
                           IntegerValue = g.Count(), // Tam sayı değerini atama
                           DoubleValue = (int)(((double)g.Count() / totalCount) * 100) // Ondalık sayıyı int'e dönüştür                       };
                       }; return PartialView(get1.ToList());
        }

    }
    }
