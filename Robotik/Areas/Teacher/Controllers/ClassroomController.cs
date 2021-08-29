using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Teacher.Controllers
{
    public class ClassroomController : Controller
    {
        RBContext db = new RBContext();
        // GET: Teacher/Classroom
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add(Classroom data)
        {
            db.Classrooms.Add(data);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Classroom updateClassroom = db.Classrooms.Find(id);
            return View(updateClassroom);
        }
        public ActionResult Update(Classroom data)
        {
            Classroom updClassroom = db.Classrooms.Find(data.ID);
            updClassroom.Name = data.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            Classroom delClassroom = db.Classrooms.Find(id);
            db.Classrooms.Remove(delClassroom);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}