using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var currentmail = (string)Session["Mail"];
            var values=c.Currents.FirstOrDefault(X=>X.Mail==currentmail);
            ViewBag.m = currentmail;
            return View(values);
        }
            public ActionResult GetTransacation ()
        {
            var currentmail = (string)Session["Mail"];
            var id=c.Currents.Where(x=>x.Mail==currentmail.ToString()).Select(y=>y.CurrentId).FirstOrDefault();
            var values = c.Transactions.Where(x => x.Currentid == id).ToList();
            
            return View(values);  
        }
    }
}