using Data;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GetCompany.Controllers
{
    public partial class HomeController : Controller
    {
        private static GetDatabaseEntities db = new GetDatabaseEntities();
        //private static UserRoleProvider userRoles = new UserRoleProvider();


        public virtual ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {    
                return RedirectToAction("Home", "Home");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public virtual ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = DALUsers.GetUsers(model.UserName, model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Home", "Home");
                }
            }
            ModelState.AddModelError("Wrong", "Wrong password or username");
            return View();
        }
        [AllowAnonymous]
        public virtual ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        public virtual ActionResult Home()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

    }
}