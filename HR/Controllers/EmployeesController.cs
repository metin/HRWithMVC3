using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Models;
using HR.Models.Data;

namespace HR.Controllers
{
    public class EmployeesController : Controller
    {
        //
        // GET: /Employees/

        public ActionResult Index()
        {
            EmployeeData d = new EmployeeData();
            ICollection<Employee> employees = d.All();
            ViewBag.employees = employees;
            ViewBag.empid = (Request.QueryString["id"] == null) ? "yok" : Request.QueryString["id"];
            return View();

        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id)
        {
            EmployeeData d = new EmployeeData();
            ViewBag.employee = d.FindById(id);
            return View();
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
            Employee e = new Employee();
            e.first_name = collection["first_name"];
            e.last_name = collection["last_name"];
            EmployeeData d = new EmployeeData();
            e = d.Save(e);
            return RedirectToAction("Index", new {id = e.id} ) ;
        }
        
        //
        // GET: /Employees/Edit/5
 
        public ActionResult Edit(int id)
        {
            EmployeeData d = new EmployeeData();
            ViewBag.employee = d.FindById(id);
            return View();
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

                Employee e = new Employee();
                e.first_name = collection["first_name"];
                e.last_name = collection["last_name"];
                e.id = id;
                EmployeeData d = new EmployeeData();
                d.Update(e);
                return RedirectToAction("Index");

        }

        //
        // GET: /Employees/Delete/5
 
        public ActionResult Delete(int id)
        {
            EmployeeData d = new EmployeeData();
            d.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
