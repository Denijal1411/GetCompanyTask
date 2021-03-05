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
    public class HomeController : Controller
    {
        GetDatabaseEntities db = new GetDatabaseEntities();



        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [AllowAnonymous] 
        public ActionResult Login(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = DALUsers.GetUsers(model.UserName,model.Password);
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
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
        public ActionResult Home()
        {
            if (HttpContext.User.Identity.IsAuthenticated) { 
                return View();
            }
            return RedirectToAction("Login", "Home");
        }

    }
}