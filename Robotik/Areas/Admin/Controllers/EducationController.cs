using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Robotik.Areas.Admin.Controllers
{
    public class EducationController : Controller
    {
        RBContext db = new RBContext();
        // GET: Admin/Education
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(Education data,HttpPostedFileBase ImagePath)
        {
            data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", ImagePath);
            db.Educations.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EducationUpdate(int? id)
        {
            Education updateEducation = db.Educations.Find(id);
            return View(updateEducation);
        }
        [HttpPost]
        public ActionResult EducationUpdate(Education data,HttpPostedFileBase ImagePath)
        {
            Education updEducation = db.Educations.Find(data.ID);
            if (ImagePath!=null)
            {
                data.ImagePath = ImageUploader.UploadSingleImage("/Uploads/", ImagePath);
            }
            else
            {
                data.ImagePath = updEducation.ImagePath;
            }
            updEducation.Name = data.Name;
            updEducation.Note = data.Note;
            updEducation.ImagePath = data.ImagePath;
            updEducation.Hour = data.Hour;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult EducationDelete(int? id)
        {
            Education delEducation = db.Educations.Find(id);
            db.Educations.Remove(delEducation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}