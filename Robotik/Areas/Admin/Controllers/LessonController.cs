using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Admin.Controllers
{
    public class LessonController : Controller
    {
        RBContext db = new RBContext();
        // GET: Admin/Lesson
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LessonAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LessonAdd(Lesson data)
        {
            db.Lessons.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult LessonUpdate(int? id)
        {
            Lesson updateLesson = db.Lessons.Find(id);
            return View(updateLesson);
        }
        [HttpPost]
        public ActionResult LessonUpdate(Lesson data)
        {
            Lesson updLesson = db.Lessons.Find(data.ID);
            updLesson.Name = data.Name;
            updLesson.Content = data.Content;
            //updLesson.Logo = data.Logo;
            updLesson.Path = data.Path;
            updLesson.Code = data.Code;
            updLesson.EducationID = data.EducationID;
            updLesson.LevelID = data.LevelID;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LessonDelete(int? id)
        {
            Lesson delLesson = db.Lessons.Find(id);
            db.Lessons.Remove(delLesson);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public JsonResult GetLevelsByEducationId(int id)
        {
            Education education = db.Educations.Find(id);
            var jsonData = from u in education.Levels
                           select new
                           {
                               ID = u.ID,
                               Name = u.Name
                           };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}