using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {

            return View( Project.FindAll());
        }

        //
        // GET: /Projects/Details/5

        public ActionResult Details(int id)
        {
            return View(Project.FindById(id));
        }

        //
        // GET: /Projects/Create

        public ActionResult Create()
        {
            ViewBag.employees = new SelectList(Employee.FindAll(), "EmpID", "FullName");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
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
            ViewBag.employees = new SelectList(Employee.FindAll(), "EmpID", "FullName");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
            return View(Project.FindById(id));
        }

        //
        // POST: /Projects/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Project project)
        {
            project.ProjID = id;
            project.Update();
            return RedirectToAction("Index");
        }

        //
        // GET: /Projects/Delete/5
 
        public ActionResult Delete(int id)
        {
            Project p = new Project { ProjID = id };
            p.Delete();
            return RedirectToAction("Index");
        }

        public ActionResult Milestones(int id)
        {
            return View(Project.FindById(id));
        }

        public ActionResult Members(int id)
        {

            ViewBag.employees = new SelectList(Employee.FindForProjectId(id), "EmpID", "EmpFName");
            ViewBag.roles = new SelectList(new string[] { "Developer", "DBA", "Manager" });

            ViewBag.project = Project.FindById(id);
            return View(ViewBag.project);
        }

        [HttpPost]
        public ActionResult Members(int ProjID, FormCollection collection, ProjectMember projectmember)
        {
            projectmember.ProjID = ProjID;
            projectmember.Save();
            return RedirectToAction("Members", new { id=ProjID});
        }

        public ActionResult Bugs(int id)
        {
            return View(Project.FindById(id));
        }
    }
}
