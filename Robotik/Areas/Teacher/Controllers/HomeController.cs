using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Teacher.Controllers
{
    public class HomeController : Controller
    {
        RBContext db = new RBContext();
        // GET: Teacher/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.EducationID == id).OrderBy(x => x.EducationID).ToList();
            return View();
        }

    }
}