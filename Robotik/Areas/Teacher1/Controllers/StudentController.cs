using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Teacher1.Controllers
{
    public class StudentController : Controller
    {
        RBContext db = new RBContext();
        // GET: Teacher1/Student
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Student data)
        {
            db.Students.Add(data);
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}