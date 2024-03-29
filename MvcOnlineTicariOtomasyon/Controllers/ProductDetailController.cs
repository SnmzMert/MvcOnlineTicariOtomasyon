using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        Context c=new Context();
        // GET: ProductDetail
        public ActionResult Index()
        {
            var values=c.Products.Where(X=>X.ProductId==1).ToList();
            return View(values);
        }
    }
}