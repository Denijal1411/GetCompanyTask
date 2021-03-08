﻿using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    [Authorize(Roles = "Administrator, Project Manager,Developer")]
    public partial class TaskController : Controller
    {
        DALTasks dal = new DALTasks();
        DALUsers dalUsers = new DALUsers();
        DALProject dalProjects = new DALProject();
        public virtual ActionResult TaskHome()
        {
            List<TaskModel> model = new List<TaskModel>();
            foreach (var item in dal.GetAll())
            {
                model.Add(new TaskModel()
                {
                    ID=item.ID,
                    Project=item.Project,
                    Assignee=item.Assignee,
                    Deadline=item.Deadline,
                    Description=item.Description,
                    Progress=item.Progress,
                    IDProject=item.IDProject,
                    Status=item.Status,
                    User=item.User
                });
            }

            if (User.IsInRole("Administrator"))//Admin vidi sve taskove dok Developer i projectManager treba da vide one na sebi 1411
            {
                return View(model);
            }
            else if (User.IsInRole("Project Manager"))//Admin vidi sve taskove dok Developer i projectManager treba da vide one na sebi 1411
            {
                //Project manager vidi taskove koji su na projektima koje on vodi 1411
                var managerProjects = dal.GetProjects ().Where(x => x.Assignee == User.Identity.Name).Select(x => x.ProjectCode);
                return View(model.Where(x => managerProjects.Contains(x.IDProject)).ToList());
            }
            else
            {
                return View(model.Where(x => x.Assignee == User.Identity.Name).ToList());
            }

        }
        [Authorize(Roles = "Administrator, Project manager")]
        /*Developer ne moze da preko linka ukuca addtask i da udje da doda task, ne moze da kaze delete task i da obrise task kao ni usera ni projekat 1411 */
        public virtual ActionResult AddTask()
        { 
            TaskCreateModel tasks = new TaskCreateModel();
            tasks.Projects = dal.GetProjects(); 
            tasks.Users = DALUsers.GetAllDevelopers();
            return View(tasks);
        }
        [HttpPost]
        public virtual ActionResult AddTask(TaskCreateModel model)
        {
            if (dalUsers.UserHasMoreTasks(model.Assignee)) { 
                ModelState.AddModelError("Assignee", $"User {model.Assignee} already has 3 tasks.");
            }
            if (ModelState.IsValid)
            {
                dal.Add(new Task()
                {
                    Assignee = model.Assignee,
                    Deadline = model.Deadline,
                    Description = model.Description.Trim(),
                    IDProject = model.IDProject,
                    Progress=0,
                    Status="New"
                });
                
                return RedirectToAction("TaskHome", "Task");
            }
            //updatujem model pre nego st oga posaljem na addTask jer mi je vratio exception 1411
            model.Projects = dal.GetProjects().ToList();
            model.Users = dalUsers.GetAll().Where(x => x.Role.Name == "Developer").ToList(); 
            return View(model);

        }
        [Authorize(Roles = "Administrator, Project manager")] //vidi moze li project manager da brise takosve 1411
        public virtual ActionResult DeleteTask(string id)
        {
            dal.Delete(new Task() { ID = Convert.ToInt32(id) });
            return RedirectToAction("TaskHome", "Task");
        }
        public virtual ActionResult EditTask(string id)
        {
            try
            {
                //AKO GA POKRENEM IZ VJUA GDE NEMA ID ON PUKNE 1411
                var task = dal.Get(new Task() { ID = Convert.ToInt32(id) });

                if (task == null) { throw new ArgumentException(""); }

                TaskModel model = new TaskModel()
                {
                    IDProject = task.IDProject,
                    Assignee = task.Assignee,
                    Progress = task.Progress,
                    Deadline = task.Deadline,
                    Description = task.Description,
                    Status = task.Status,
                    Projects = dalProjects.GetAll(),
                    Statuses = dal.GetStatuses()
                };
                ViewBag.getProject = model.Projects.FirstOrDefault(x => x.ProjectCode == model.IDProject).ProjectName;
                ViewBag.currentAssignee = model.Assignee;
                model.Users = GetAllUsersWithCurrentRole();  
                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("UserHome", "User");
            }

        }
        [HttpPost]
        public virtual ActionResult EditTask(TaskModel model)
        {
            if (ModelState.IsValid)
            {
                dal.Update(new Task()
                {
                    Assignee = model.Assignee,
                    Deadline = model.Deadline,
                    Description = model.Description.Trim(),
                    ID = model.ID,
                    IDProject = model.IDProject,
                    Progress = model.Progress,
                    Status = model.Status
                });
                return RedirectToAction("TaskHome", "Task");
            } 
            model.Statuses = dal.GetStatuses();
            model.Projects = dalProjects.GetAll();
            model.Users = GetAllUsersWithCurrentRole();
            return View(model);

        }

        #region Method without ActionResult
        public List<User> GetAllUsersWithCurrentRole()
        {

            if (User.IsInRole("Project manager"))
            {

                return DALUsers.GetAllDevelopers().ToList();
            }
            else if (User.IsInRole("Administrator"))
            {
                return DALUsers.GetNonAdminUsers().ToList();
            }
            else
            {
                return  new List<User>() { dalUsers.Get(new User() { UserName = User.Identity.Name }) };
            }
        }
        #endregion
    }
}