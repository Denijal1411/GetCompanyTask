﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetCompany.Controllers
{
    public partial class TaskController : Controller
    {
        // GET: Task
        public virtual ActionResult TaskHome()
        {
            return View();
        }
    }
}