using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    [Authorize(Roles = "Administrator")]
    public partial class ProjectController : Controller
    {
        DALProject dal = new DALProject();
        public virtual ActionResult ProjectHome()
        { 
            return View(dal.GetAll());
        }
        public virtual ActionResult AddProject()
        { 
            ProjectModel a = new ProjectModel();  
            a.Users = dal.GetManagers(); 
            return View(a);
        } 
        [HttpPost]
        public virtual ActionResult AddProject(ProjectModel model)
        {
            if (ModelState.IsValid) {
                dal.Add(new Project(){ProjectName = model.Name,Assignee=model.Assignee});
                return RedirectToAction("ProjectHome", "Project");
            }
            return View();
              
        }
        public virtual ActionResult DeleteProject(string projectCode)
        {
            dal.Delete(new Project() { ProjectCode = Convert.ToInt32(projectCode)});
            return RedirectToAction("ProjectHome", "Project");
        }
        public virtual ActionResult EditProject(string projectCode)
        {
            try
            {
                var project = dal.Get(new Project() { ProjectCode=Convert.ToInt32(projectCode)});
                if (project == null) { throw new ArgumentException("project is null"); } 

                return View(new ProjectModel(){
                    Name=project.ProjectName,
                    ProjectCode=project.ProjectCode
                });
            }
            catch (Exception e)
            {
                return RedirectToAction("ProjectHome", "Project");
            }

        }
        [HttpPost]
        public virtual ActionResult EditProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                dal.Update(new Project()
                {
                    ProjectCode=model.ProjectCode,
                    ProjectName=model.Name
                });
                return RedirectToAction("ProjectHome", "Project");
            }
            return View();

        }
    }
}