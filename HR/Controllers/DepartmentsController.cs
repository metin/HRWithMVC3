using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Data;

namespace HR.Controllers
{
    public class DepartmentsController : Controller
    {
        //
        // GET: /Departments/

        public ActionResult Index()
        {
            DepartmentData d = new DepartmentData();
            ICollection<Department> departments = d.All();
            ViewBag.departments = departments;
            return View();
        }

        //
        // GET: /Departments/Details/5

        public ActionResult Details(int id)
        {
            DepartmentData d = new DepartmentData();
            return View(d.FindById(id));
        }

        //
        // GET: /Departments/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Departments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Department p = new Department();
            p.name = collection["name"];
            DepartmentData d = new DepartmentData();
            p = d.Save(p);
            return RedirectToAction("Index", new { id = p.id });
        }
        
        //
        // GET: /Departments/Edit/5
 
        public ActionResult Edit(int id)
        {
            DepartmentData d = new DepartmentData();
            return View(d.FindById(id));
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Department e = new Department();
            e.name = collection["name"];
            e.id = id;
            DepartmentData d = new DepartmentData();
            d.Update(e);
            return RedirectToAction("Index");
        }

        //
        // GET: /Departments/Delete/5
 
        public ActionResult Delete(int id)
        {
            DepartmentData d = new DepartmentData();
            d.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
