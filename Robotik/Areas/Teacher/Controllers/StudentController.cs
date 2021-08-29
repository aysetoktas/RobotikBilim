using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Teacher.Controllers
{
    public class StudentController : Controller
    {
        RBContext db = new RBContext();
        // GET: Teacher/Student
        public ActionResult Index()
        {
            return View();
        }
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
        public ActionResult Add(User data)
        {
            data.Role = Role.Student;
            db.Users.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            User updateUser = db.Users.Find(id);
            return View(updateUser);
        }
        [HttpPost]
        public ActionResult Update(User data)
        {
            User updUser = db.Users.Find(data.ID);
            updUser.FirstName = data.FirstName;
            updUser.LastName = data.LastName;
            updUser.UserName = data.UserName;
            updUser.Email = data.Email;
            updUser.Password = data.Password;
            updUser.PhoneNumber = data.PhoneNumber;
            //updUser.ClassroomID = data.ClassroomID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            User delUser = db.Users.Find(id);
            db.Users.Remove(delUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}