using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GallaryPortal.Areas.Cp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Cp/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}