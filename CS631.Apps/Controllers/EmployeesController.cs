using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.HR.Controllers
{
    public class EmployeesController : Controller
    {

        public ActionResult Index()
        {
            return View(Employee.FindAll());
        }

        public ActionResult Details(int id)
        {
            return View(Employee.FindById(id));
        }

        public ActionResult Create()
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "BuildingID", "BuildingName");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
            ViewBag.offices = new SelectList(Office.FindAll(), "OfficeID", "OfficeNumber");
            ViewBag.divisions = new SelectList(Division.FindAll(), "DivID", "DivName");
            ViewBag.employment = new SelectList(new string[] {"H", "S" });
            return View();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection, Employee e)
        {
            e.Save();
            return RedirectToAction("Index", new {id = e.EmpID} ) ;
        }
        
        public ActionResult Edit(int id)
        {
            ViewBag.buildings = new SelectList(Building.FindAll(), "BuildingID", "BuildingName");
            ViewBag.departments = new SelectList(Department.FindAll(), "DeptID", "DeptName");
            ViewBag.offices = new SelectList(Office.FindAll(), "OfficeID", "OfficeNumber");
            ViewBag.divisions = new SelectList(Division.FindAll(), "DivID", "DivName");
            ViewBag.employment = new SelectList(new string[] { "H", "S" });
            return View(Employee.FindById(id));
        }

        [HttpPost]
        public ActionResult Edit(int EmpID, FormCollection collection, Employee e)
        {
            e.EmpID = EmpID;
            e.Update();
            return RedirectToAction("Index");
        }


        public ActionResult Salary(int id)
        {
            Employee emp = Employee.FindById(id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Salary(int EmpID, EmployeeSalary employeeSalary)
        {
            employeeSalary.EmpID = EmpID;
            employeeSalary.Save();
            return RedirectToAction("Salary", new { id = EmpID});
        }

        public ActionResult Payroll(int id)
        {
            Employee emp = Employee.FindById(id);
            ViewBag.employee = emp;
            return View(emp);
        }

        [HttpPost]
        public ActionResult Payroll(int EmpID, Payroll payroll)
        {
            payroll.EmpID = EmpID;
            payroll.Save();
            return RedirectToAction("Payroll", new { id = EmpID });
        }

        public ActionResult Delete(int id)
        {
            Employee e = new Employee { EmpID = id };
            e.Delete();
            return RedirectToAction("Index");
        }


    }
}
