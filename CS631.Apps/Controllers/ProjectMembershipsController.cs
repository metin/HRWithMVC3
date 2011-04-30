using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS631.Data;

namespace CS631.Apps.Controllers
{
    public class ProjectMembershipsController : Controller
    {



 
        public ActionResult Delete(int id)
        {
            ProjectMember m = ProjectMember.FindByID(id);
            m.Delete();
            return RedirectToAction("Members", "Projects", new { id = m.ProjID });
        }

        public ActionResult Finish(int id)
        {
            ProjectMember m = ProjectMember.FindByID(id);
            m.Finish();
            return RedirectToAction("Members", "Projects", new { id = m.ProjID });
        }

    }
}
