using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class OfficesController : Controller
    {
        //
        // GET: /Rooms/

        public ActionResult Index()
        {
            return View(Office.FindAll());
        }

        //
        // GET: /Rooms/Details/5

        public ActionResult Details(int id)
        {
            return View(Office.FindById(id));
        }

        //
        // GET: /Rooms/Create

        public ActionResult Create()
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "BuildingID", "BuildingCode");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
            ViewBag.types = new SelectList(new string[] { "T1", "T2" });
            return View();
        } 

        //
        // POST: /Rooms/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Office office)
        {
            office.Save();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Rooms/Edit/5
 
        public ActionResult Edit(int id)
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "BuildingID", "BuildingCode");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
            ViewBag.types = new SelectList(new string[] { "T1", "T2" });
            return View(Office.FindById(id));
        }

        //
        // POST: /Rooms/Edit/5

        [HttpPost]
        public ActionResult Edit(int OfficeID, FormCollection collectionn, Office office)
        {
            office.OfficeID = OfficeID;
            office.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Rooms/Delete/5
 
        public ActionResult Delete(int id)
        {
            Office p = new Office { OfficeID = id };
            p.Delete();
            return RedirectToAction("Index");
        }


    }
}
