using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.HR.Controllers
{
    public class RoomsController : Controller
    {
        //
        // GET: /Rooms/

        public ActionResult Index()
        {
            Room r = new Room();
            return View(r.All());
        }

        //
        // GET: /Rooms/Details/5

        public ActionResult Details(int id)
        {
            Room r = new Room { Id = id };
            return View(r.Load());
        }

        //
        // GET: /Rooms/Create

        public ActionResult Create()
        {
            var selectList = new Building().All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            ViewBag.buildings = new Building().All(); //selectList;
            return View();
        } 

        //
        // POST: /Rooms/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection, Room room)
        {
            room.Save();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Rooms/Edit/5
 
        public ActionResult Edit(int id)
        {
            Room r = new Room { Id = id };
            return View(r.Load());
        }

        //
        // POST: /Rooms/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collectionn, Room room)
        {
            room.Id = id;
            room.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Rooms/Delete/5
 
        public ActionResult Delete(int id)
        {
            Room p = new Room { Id = id };
            p.Delete();
            return RedirectToAction("Index");
        }


    }
}
