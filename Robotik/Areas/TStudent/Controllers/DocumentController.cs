using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Areas.TStudent.Controllers
{
    public class DocumentController : Controller
    {
        RBContext db = new RBContext();
        // GET: TStudent/Document
        public ActionResult ClassroomList()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            return View();
        }
        public ActionResult DocumentList(int? id)
        {
            List<Document> documents = db.Documents.Where(x => x.CategoryID == id).ToList();
            return View(documents);
        }
        public ActionResult SingleDocument(int? id)
        {
            Document document = db.Documents.Find(id);
            return View(document);
        }
    }
}