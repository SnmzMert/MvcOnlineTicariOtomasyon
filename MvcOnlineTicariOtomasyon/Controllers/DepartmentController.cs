using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var items = c.Departments.Where(x => x.IsActive == true).ToList();
            return View(items);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddDepartment(Department p)
        {
            c.Departments.Add(p);
          
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveDepartment(int id)
        {
            var prod = c.Departments.Find(id);
            prod.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateDepartment(int id)
        {

            var cat = c.Departments.Find(id);
            return View("UpdateDepartment", cat);
        }

        public ActionResult DepartmentUpdate(Department departments)
        {
            var cat = c.Departments.Find(departments.DepartmentId);
            cat.DepartmentName = departments.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        { 
            var values=c.Employees.Where(x=>x.Departmentid==id).ToList();
            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.d = dpt;
            return View(values); }

        public ActionResult DepartmentEmploeeMove(int id)
        {
            var values=c.Transactions.Where(x=>x.Employeeid==id).ToList();
            var emp = c.Employees
            .Where(x => x.EmployeeId == id)
            .Select(y => y.FirstName + " " + y.LastName)
            .FirstOrDefault();

            ViewBag.d = emp;
            return View(values);
            
            
        }
    }
}
