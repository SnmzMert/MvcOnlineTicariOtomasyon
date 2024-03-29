using MvcOnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.Where(x=>x.IsActive==true).ToList();
            return View(values);
        }
        public ActionResult UpdatePersonel(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.Department = value1;
            var personel = c.Employees.Find(id);
            return View(personel);
        }
        public ActionResult PersonelUpdate(Employee p)
        {
            var emp = c.Employees.Find(p.EmployeeId);
            emp.EmployeeImage = p.EmployeeImage;
            emp.Address = p.Address;
            emp.FirstName = p.FirstName;
            emp.LastName = p.LastName;
            emp.Phone = p.Phone;
            emp.Departmentid = p.Departmentid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeletePersonel(int id)
        {
            var personel = c.Employees.Find(id);
            personel.IsActive = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult AddPersonel()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.Department = value1;

            return View();
        }
        [HttpPost]
        public ActionResult AddPersonel(Employee p)
        {
            c.Employees.Add(p);
            p.IsActive = true;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelDetail(int id)
        {
            var values = c.Transactions.Where(x => x.Employeeid == id).ToList();
            var emp = c.Employees
            .Where(x => x.EmployeeId == id)
            .Select(y => y.FirstName + " " + y.LastName)
            .FirstOrDefault();

            ViewBag.d = emp;
            return View(values);
        }
    }
}
