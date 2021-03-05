using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    public partial class UserController : Controller
    {
        // GET: User
        public virtual ActionResult UserHome()
        {
            return View();
        }
        [HttpGet]
        public virtual ActionResult AddUser()
        {
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
    }
}