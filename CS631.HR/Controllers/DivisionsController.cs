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
            return View();
        } 

        //
        // POST: /Departments/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Division d = new Division { name = collection["name"] };
            d.Save();
            return RedirectToAction("Index", new { id = d.id });
        }
        
        //
        // GET: /Departments/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(Division.FindByID(id));
        }

        //
        // POST: /Departments/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Division e = new Division { name = collection["name"], id = id };
            e.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Departments/Delete/5
 
        public ActionResult Delete(int id)
        {
            Division d = new Division { id = id };
            d.Delete();
            return RedirectToAction("Index");
        }


    }
}
