using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.TStudent.Controllers
{
    public class HomeController : Controller
    {
        // GET: TStudent/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}