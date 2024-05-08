using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Currents.Where(x => x.IsActive == true).ToList();
            return View(values);
        }
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current p)
        {
            if(!ModelState.IsValid)
            {
                return View("AddCurrent");
            }

            c.Currents.Add(p);

            p.IsActive = true;

            c.SaveChanges();
            ViewBag.ShowAlert = true;
            return RedirectToAction("Index");
        }

        public ActionResult RemoveCurrent(int id)
        {
            var cur = c.Currents.Find(id);
            cur.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrent(int id)
        {

            {

                var cur = c.Currents.Find(id);
                return View("GetCurrent", cur);
            }

        }
        public ActionResult UpdateCurrent(Current p)
        {
            var cur = c.Currents.Find(p.CurrentId);
            cur.CurrentName = p.CurrentName;
            cur.CurrentAmount = p.CurrentAmount;
            cur.City = p.City;
            cur.Country = p.Country;
            cur.Description = p.Description;
            cur.Mail = p.Mail;
            cur.Phone = p.Phone;
            cur.TaxOffice = p.TaxOffice;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCurrentMoves(int id)
        {
            var values = c.Transactions.Where(x => x.Currentid == id).ToList();
            var cur = c.Currents
            .Where(x => x.CurrentId == id)
            .Select(y => y.CurrentName)
            .FirstOrDefault();

            ViewBag.d = cur;
            return View(values);
        }
    }
}