using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.HR.Controllers
{
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/

        public ActionResult Index()
        {
            Employee d = new Employee();
            ICollection<Employee> employees = d.All();
            ViewBag.employees = employees;
            ViewBag.empid = (Request.QueryString["id"] == null) ? "yok" : Request.QueryString["id"];
            return View();

        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id)
        {
            Employee d = new Employee { id = id } ;
            return View(d.Load());
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Employees/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Employee e = new Employee
            {
                first_name = collection["first_name"],
                last_name = collection["last_name"]
            };
            e.Save();
            return RedirectToAction("Index", new {id = e.id} ) ;
        }
        
        //
        // GET: /Employees/Edit/5
 
        public ActionResult Edit(int id)
        {
            Employee d = new Employee { id = id };
            return View(d.Load());
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Employee e = new Employee
            {
                first_name = collection["first_name"],
                last_name = collection["last_name"],
                id = id
            };
            e.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Employees/Delete/5
 
        public ActionResult Delete(int id)
        {
            Employee e = new Employee { id = id };
            e.Delete();
            return RedirectToAction("Index");
        }


    }
}
