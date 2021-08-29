using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.Admin.Controllers
{
    public class LevelController : Controller
    {
        RBContext db = new RBContext();
        // GET: Admin/Level
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LevelAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LevelAdd(Level data)
        {
            db.Levels.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult LevelUpdate(int? id)
        {
            Level updateLevel = db.Levels.Find(id);
            return View(updateLevel);
        }
        [HttpPost]
        public ActionResult LevelUpdate(Level data)
        {
            Level updLevel = db.Levels.Find(data.ID);
            updLevel.EducationID = data.EducationID;
            updLevel.Name = data.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult LevelDelete(int? id)
        {
            Level delLevel = db.Levels.Find(id);
            db.Levels.Remove(delLevel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}