using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class MilestonesController : Controller
    {

        public ActionResult Index()
        {
            return View(Milestone.FindAll());
        }

        public ActionResult Details(int id)
        {
            return View(Milestone.FindByID(id));
        }

        public ActionResult Create()
        {
            ViewBag.projects = new SelectList(Project.FindAll(), "ProjID", "ProjectNO");
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection, Milestone milestone)
        {
            milestone.Save();
            return RedirectToAction("Index");
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.projects = new SelectList(Project.FindAll(), "ProjID", "ProjectNO");
            return View(Milestone.FindByID(id));
        }

        [HttpPost]
        public ActionResult Edit(int MilestoneID, FormCollection collection, Milestone milestone)
        {
            milestone.MilestoneID = MilestoneID;
            milestone.Update();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

    }
}
