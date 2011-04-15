using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR.Data;

namespace HR.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            ProjectData d = new ProjectData();
            ICollection<Project> projects = d.All();
            ViewBag.projects = projects;
            return View();
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id)
        {
            ProjectData d = new ProjectData();
            return View(d.FindById(id));
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Projects/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Project p = new Project();
            p.name = collection["name"];
            ProjectData d = new ProjectData();
            p = d.Save(p);
            return RedirectToAction("Index", new { id = p.id });
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProjectData d = new ProjectData();
            return View(d.FindById(id));
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Project e = new Project();
            e.name = collection["name"];
            e.id = id;
            ProjectData d = new ProjectData();
            d.Update(e);
            return RedirectToAction("Index");
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProjectData d = new ProjectData();
            d.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
