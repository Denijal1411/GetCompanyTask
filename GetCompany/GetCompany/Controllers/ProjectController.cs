using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    [Authorize(Roles = "Administrator, Project Manager")]
    public partial class ProjectController : Controller
    {
        DALProject dal = new DALProject();
        public virtual ActionResult ProjectHome()
        { 
            return View(dal.GetAll());
        }
        public virtual ActionResult AddProject()
        { 
            ProjectModel allManagers = new ProjectModel();
            allManagers.Users = dal.GetManagers();
            allManagers.Assignee = User.Identity.Name;
            return View(allManagers);
        }
        public virtual ActionResult DetailProject()
        {
            return View();
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
                ProjectModel allManagers = new ProjectModel();
                allManagers.Users = dal.GetManagers();

                return View(new ProjectModel(){
                    Name=project.ProjectName,
                    ProjectCode=project.ProjectCode,
                    Assignee=project.Assignee ,
                    Users= allManagers.Users
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
                    ProjectName=model.Name,
                    Assignee=model.Assignee
                });
                return RedirectToAction("ProjectHome", "Project");
            }
            return View();

        }
    }
}