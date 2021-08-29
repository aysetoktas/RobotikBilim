using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.STeacher.Controllers
{
    public class EducationController : Controller
    {
        RBContext db = new RBContext();
        // GET: STeacher/Education
        public ActionResult EducationList()
        {
            return View();
        }
        public ActionResult LevelList(int? id)
        {
            List<Level> levels = db.Levels.Where(x => x.EducationID == id).ToList();
            return View(levels);
        }
        public ActionResult LessonList(int? id)
        {
            List<Lesson> lessons = db.Lessons.Where(x => x.LevelID == id).ToList();
            return View(lessons);
        }
        public ActionResult SingleLesson(int? id)
        {
            Lesson lesson = db.Lessons.Find(id);
            return View(lesson);
        }
    }
}