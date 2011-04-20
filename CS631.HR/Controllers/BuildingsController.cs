using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.HR.Controllers
{
    public class BuildingsController : Controller
    {
        //
        // GET: /Buildings/

        public ActionResult Index()
        {
            Building b = new Building();
            return View(b.All());
        }

        //
        // GET: /Buildings/Details/5

        public ActionResult Details(int id)
        {
            Building b = new Building { Id = id };
            return View(b.Load());
        }

        //
        // GET: /Buildings/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Buildings/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Building building)
        {
            building.Save();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Buildings/Edit/5
 
        public ActionResult Edit(int id)
        {
            Building b = new Building { Id = id };
            return View(b.Load());
        }

        //
        // POST: /Buildings/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Building buiding)
        {
            buiding.Id = id;
            buiding.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Buildings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Building p = new Building { Id = id };
            p.Delete();
            return RedirectToAction("Index");
        }

    }
}
