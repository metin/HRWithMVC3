using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Controllers
{
    public class DivisionsController : Controller
    {
        //
        // GET: /Departments/

        public ActionResult Index()
        {
            return View(Division.FindAll());
        }

        //
        // GET: /Departments/Details/5

        public ActionResult Details(int id)
        {
            return View(Division.FindByID(id));
        }

        //
        // GET: /Departments/Create

        public ActionResult Create()
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "id", "EmpFName");
            return View();
        } 

        //
        // POST: /Departments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Division d)
        {
            d.Save();
            return RedirectToAction("Index", new { id = d.DivID });
        }
        
        //
        // GET: /Departments/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "DivID", "EmpFName");
            return View(Division.FindByID(id));
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collectio, Division d)
        {
            d.DivID = id;
            d.Update();
            return RedirectToAction("Index");
        }

        public ActionResult Departments(int id)
        {
            return View(Division.FindByID(id));
        }

        //
        // GET: /Departments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Division d = new Division { DivID = id };
            d.Delete();
            return RedirectToAction("Index");
        }


    }
}
