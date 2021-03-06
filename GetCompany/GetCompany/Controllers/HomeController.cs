using Data;
using GetCompany.Code;
using GetCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;

namespace GetCompany.Controllers
{
    public partial class HomeController : Controller
    {  
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
                var user = DALUsers.CheckUser(model.UserName, model.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);  
                    return RedirectToAction("Home", "Home");
                }
            }
            ModelState.AddModelError("Wrong", "Wrong password or username");
            return View();
        }  
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