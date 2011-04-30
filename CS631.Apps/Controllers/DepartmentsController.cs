using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class DepartmentsController : Controller
    {
        //
        // GET: /Departments/

        public ActionResult Index()
        {
            return View(Department.FindAll());
        }

        //
        // GET: /Departments/Details/5

        public ActionResult Details(int id)
        {
            return View(Department.FindById(id));
        }

        //
        // GET: /Departments/Create

        public ActionResult Create()
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "EmpID", "EmpFName");
            ViewBag.divisions = new SelectList(Division.FindAll(), "DivID", "DivName");
            return View();
        } 

        //
        // POST: /Departments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Department d)
        {
            d.Save();
            return RedirectToAction("Index", new { id = d.DeptID });
        }
        
        //
        // GET: /Departments/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "EmpID", "EmpFName");
            ViewBag.divisions = new SelectList(Division.FindAll(), "DivID", "DivName");
            return View(Department.FindById(id));
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        public ActionResult Edit(int DeptID, FormCollection collection, Department d)
        {
            d.DeptID = DeptID;
            d.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Departments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Department d = new Department { DeptID = id };
            d.Delete();
            return RedirectToAction("Index");
        }


    }
}
