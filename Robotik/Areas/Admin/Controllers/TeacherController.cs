using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        RBContext db = new RBContext();
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult TeacherAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TeacherAdd(Entity.Teacher data)
        {
            db.Teachers.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult TeacherUpdate(int? id)
        {
            Entity.Teacher updateTeacher = db.Teachers.Find(id);
            return View(updateTeacher);
        }
        [HttpPost]
        public ActionResult TeacherUpdate(Entity.Teacher data)
        {
            Entity.Teacher updTeacher = db.Teachers.Find(data.ID);
            updTeacher.UserName = data.UserName;
            updTeacher.FirstName = data.FirstName;
            updTeacher.LastName = data.LastName;
            updTeacher.Email = data.Email;
            updTeacher.Password = data.Password;
            updTeacher.PhoneNumber = data.PhoneNumber;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult TeacherDelete(int? id)
        {
            Entity.Teacher delTeacher = db.Teachers.Find(id);
            db.Teachers.Remove(delTeacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult toEducation(int? id)
        {
            Entity.Teacher teacher = db.Teachers.Find(id);
            return View(teacher);
        }
        [HttpPost]
        public ActionResult toEducation(int? id,int? educationID)
        {
            Entity.Education education = db.Educations.Find(educationID);
            Entity.Teacher teacher = db.Teachers.Find(id);
            education.Teachers.Add(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}