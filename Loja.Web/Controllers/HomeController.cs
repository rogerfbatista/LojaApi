﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loja.Application.Interfaces;

namespace Loja.Web.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {


         return Redirect("~/Index.html");
        }
    }
}
