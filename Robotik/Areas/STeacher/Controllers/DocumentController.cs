using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Utility;

namespace Robotik.Areas.STeacher.Controllers
{
    public class DocumentController : Controller
    {
        RBContext db = new RBContext();
        // GET: STeacher/Document
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
        public ActionResult Add(Document data, HttpPostedFileBase Pdf)
        {
            Document doc = new Document();
            doc.Path = PdfUploader.UploadPdf("/UploadContent/", Pdf);
            doc.Name = data.Name;
            doc.Description = data.Description;
            doc.CategoryID = data.CategoryID;
            db.Documents.Add(doc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(int? id)
        {
            Entity.Document updateDocument = db.Documents.Find(id);
            return View(updateDocument);
        }
        [HttpPost]
        public ActionResult Update(Document data, HttpPostedFileBase Pdf, string[] classrooms)
        {
            Document updDocument = db.Documents.Find(data.ID);
            if (Pdf != null)
            {
                data.Path = PdfUploader.UploadPdf("/UploadContent/", Pdf);

            }
            else
            {
                data.Path = updDocument.Path;
            }
            updDocument.Name = data.Name;
            updDocument.Description = data.Description;
            updDocument.Path = data.Path;
            updDocument.CategoryID = data.CategoryID;
            updDocument.Classrooms.Clear();
            db.SaveChanges();
            foreach (string cat in classrooms)
            {
                int catId = Convert.ToInt32(cat);
                Classroom classroom = db.Classrooms.Find(catId);
                updDocument.Classrooms.Add(classroom);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            Document delDocument = db.Documents.Find(id);
            db.Documents.Remove(delDocument);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult toClassroom(int? id)
        {
            Entity.Document document = db.Documents.Find(id);
            return View(document);
        }
        [HttpPost]
        public ActionResult toClassroom(int? id, int? classroomID)
        {
            Classroom classroom = db.Classrooms.Find(classroomID);
            Entity.Document document = db.Documents.Find(id);
            classroom.Documents.Add(document);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}