using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Register()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Register(Current p)
        {
            c.Currents.Add(p);
            c.SaveChanges();
            return PartialView();
        }


        [HttpGet]
        public ActionResult LoginCurrent1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCurrent1(Current p)
        {
            var info=c.Currents.FirstOrDefault(x=>x.Mail==p.Mail && x.Password==p.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.Mail, false);
                Session["Mail"] = info.Mail.ToString();
                return RedirectToAction("Index", "CurrentPanel");

            }
            else
            {
                return View("Index","Login");
            }
        }

        [HttpGet]
        public PartialViewResult LoginPersonel()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult LoginPersonel(Current p)
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult LoginPersonel1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPersonel1(Admin p)
        {
            var info = c.Admins.FirstOrDefault(x => x.UserName == p.UserName && x.Password == p.Password);
            if (info != null)
            {
                FormsAuthentication.SetAuthCookie(info.UserName, false);
                Session["UserName"] = info.UserName.ToString();
                return RedirectToAction("Index", "Statistics");

            }
            else
            {
                return View("Index", "Login");
            }
        }
    }
}