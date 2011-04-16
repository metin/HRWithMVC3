using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.HR.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            Project p = new Project();
            ICollection<Project> projects = p.All();
            ViewBag.projects = projects;
            return View();
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id)
        {
            Project p = new Project { id = id };
            return View(p.Load());
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
        public ActionResult Create(FormCollection collection, Project project)
        {
            project.Save();
            return RedirectToAction("Index");
        }
        
        //
        // GET: /Projects/Edit/5
 
        public ActionResult Edit(int id)
        {
            Project p = new Project { id = id };
            return View(p.Load());
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Project project)
        {
            Project p = new Project { name = collection["name"], id = id };
            //p.Update();
            project.id = id;
            project.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project p = new Project { id = id };
            p.Delete();
            return RedirectToAction("Index");
        }


    }
}
