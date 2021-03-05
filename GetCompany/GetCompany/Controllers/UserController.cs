using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    [Authorize(Roles="Administrator")]
    public partial class UserController : Controller
    {
        // GET: User 
        public virtual ActionResult UserHome()
        {
            var users = DALUsers.GetAllUsers().ToList(); 
            return View(users);
        }
        [HttpGet]
        public virtual ActionResult AddUser()
        {
            var s = DALUserRoles.GetUserRole(HttpContext.User.Identity.Name);
            return View();
        }
        [HttpPost]
        public virtual ActionResult AddUser(CreateUserModel model)
        {
            if (ModelState.IsValid) {
                DALUsers.AddUser(model.Name, model.Surname, model.Email, model.Password, model.UserName, model.IDRole);
                return RedirectToAction("UserHome", "User");
            }
            return View();
            
        }
        public virtual ActionResult DeleteUser(string username) {
            DALUsers.DeleteUser(username);
            return RedirectToAction("UserHome", "User");
        }
    }
}