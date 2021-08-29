using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.STeacher.Controllers
{
    public class StudentController : Controller
    {
        RBContext db = new RBContext();
        // GET: STeacher/Student
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
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Entity.Student updateStudent = db.Students.Find(id);
            return View(updateStudent);
        }
        [HttpPost]
        public ActionResult Update(Entity.Student data)
        {
            Entity.Student updStudent = db.Students.Find(data.ID);
            updStudent.UserName = data.UserName;
            updStudent.FirstName = data.FirstName;
            updStudent.LastName = data.LastName;
            updStudent.Email = data.Email;
            updStudent.Password = data.Password;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            Entity.Student delStudent = db.Students.Find(id);
            db.Students.Remove(delStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult toClassroom(int? id)
        {
            Entity.Student student = db.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult toClassroom(int? id, int? classroomID)
        {
            Classroom classroom = db.Classrooms.Find(classroomID);
            Entity.Student student = db.Students.Find(id);
            classroom.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}