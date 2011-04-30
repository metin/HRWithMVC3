using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class BuildingsController : Controller
    {
        //
        // GET: /Buildings/

        public ActionResult Index()
        {
            Building b = new Building();
            return View(Building.FindAll());
        }

        //
        // GET: /Buildings/Details/5

        public ActionResult Details(int id)
        {
            return View(Building.FindById(id));
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
            return View(Building.FindById(id));
        }

        //
        // POST: /Buildings/Edit/5

        [HttpPost]
        public ActionResult Edit(int BuildingID, FormCollection collection, Building buiding)
        {
            buiding.BuildingID = BuildingID;
            buiding.Update();
            return RedirectToAction("Index");
        }

        public ActionResult Rooms(int id)
        {
            return View(Building.FindById(id));
        }

        public ActionResult Offices(int id)
        {
            return View(Building.FindById(id));   
        }
        //
        // GET: /Buildings/Delete/5
 
        public ActionResult Delete(int id)
        {
            Building p = new Building { BuildingID = id };
            p.Delete();
            return RedirectToAction("Index");
        }

    }
}
