using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class BugsController : Controller
    {
        public ActionResult Index(string status, string type)
        {
            ViewBag.statees = new SelectList(new string[] { "Open", "In Process", "Closed" }, status);
            ViewBag.types = new SelectList(new string[] { "Bug", "Feature", "Request" }, type);
            return View(Bug.FilterAll(status, type));
        }

        public ActionResult Details(int id)
        {
            return View(Bug.FindByID(id));
        }

        public ActionResult Create()
        {
            ViewBag.types = new SelectList(new string[] { "Bug", "Feature", "Request" });
            ViewBag.projects = new SelectList(Project.FindAll(), "ProjID", "ProjectNO");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection, Bug bug)
        {
            bug.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "EmpID", "FullName");
            ViewBag.statees = new SelectList(new string[] { "Open", "In Process", "Closed" });
            ViewBag.types = new SelectList(new string[] { "Bug", "Feature", "Request" });
            ViewBag.projects = new SelectList(Project.FindAll(), "ProjID", "ProjectNO");
            return View(Bug.FindByID(id));
        }

        [HttpPost]
        public ActionResult Edit(int BugID, FormCollection collection, Bug bug)
        {
            bug.BugID = BugID;
            bug.Update();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var b = Bug.FindByID(id);
            b.Delete();
            return RedirectToAction("Index");
        }

    }
}
