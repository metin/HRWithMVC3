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
            return View(Employee.FindAll());
        }

        //
        // GET: /Employees/Details/5

        public ActionResult Details(int id)
        {
            return View(Employee.FindById(id));
        }

        //
        // GET: /Employees/Create

        public ActionResult Create()
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "id", "name");
            ViewBag.departments = new SelectList(Department.FindAll(), "id", "name");
           // ViewBag.offices = new SelectList(Office.FindAll(), "id", "code");
            ViewBag.divisions = new SelectList(Division.FindAll(), "id", "name");

            ViewBag.employment = new SelectList(new string[] {"H", "S" });
            

            return View();
        } 

        //
        // POST: /Employees/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Employee e)
        {
            e.Save();
            return RedirectToAction("Index", new {id = e.id} ) ;
        }
        
        //
        // GET: /Employees/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "id", "name");
            ViewBag.departments = new SelectList(Department.FindAll(), "id", "name");
            // ViewBag.offices = new SelectList(Office.FindAll(), "id", "code");
            ViewBag.divisions = new SelectList(Division.FindAll(), "id", "name");

            ViewBag.employment = new SelectList(new string[] { null, "H", "S" });

            return View(Employee.FindById(id));
        }

        //
        // POST: /Employees/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Employee e)
        {
            e.id = id;
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
