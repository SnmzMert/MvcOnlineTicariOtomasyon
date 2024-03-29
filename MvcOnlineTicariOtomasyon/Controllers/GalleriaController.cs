using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Controllers;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleriaController : Controller
    {
        // GET: Galleria
       Context c=new Context();
        public ActionResult Index()
        {
            var values=c.Products.Where(x=>x.IsActive==true).ToList();
            return View(values);
        }
    }
}