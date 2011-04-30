using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class RoomsController : Controller
    {

        public ActionResult Index()
        {
            Room r = new Room();
            return View(Room.FindAll());
        }

        public ActionResult Details(int id)
        {
            return View(Room.FindById(id) );
        }

        public ActionResult Create()
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "id", "code");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection, Room room)
        {
            room.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "id", "code");
            return View(Room.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collectionn, Room room)
        {
            room.Id = id;
            room.Update();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Room p = new Room { Id = id };
            p.Delete();
            return RedirectToAction("Index");
        }
    
    }
}
