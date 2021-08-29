using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.STeacher.Controllers
{
    public class CategoryController : Controller
    {
        RBContext db = new RBContext();
        // GET: STeacher/Category
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
        public ActionResult Add(Category data)
        {
            db.Categories.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Entity.Category updateCategory = db.Categories.Find(id);
            return View(updateCategory);
        }
        [HttpPost]
        public ActionResult Update(Entity.Category data)
        {
            Entity.Category updCategory = db.Categories.Find(data.ID);
            updCategory.Name = data.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            Entity.Category delCategory = db.Categories.Find(id);
            db.Categories.Remove(delCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}