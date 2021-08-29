using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.ATeacher.Controllers
{
    public class StudentController : Controller
    {
        RBContext db = new RBContext();
        // GET: ATeacher/Student
        public ActionResult Index()
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
            return RedirectToAction("Index");
        }
    }
}