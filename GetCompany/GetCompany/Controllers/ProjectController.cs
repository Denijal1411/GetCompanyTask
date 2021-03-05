using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    public partial class ProjectController : Controller
    {
        // GET: Project
        public virtual ActionResult ProjectHome()
        {
            return View();
        }
    }
}