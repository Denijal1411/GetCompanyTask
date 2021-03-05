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
        public virtual ActionResult ProjectHome()
        {
            return View();
        }
    }
}