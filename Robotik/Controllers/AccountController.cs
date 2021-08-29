using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Robotik.Controllers
{
    public class AccountController : Controller
    {
        RBContext db = new RBContext();
        // GET: Account
        public ActionResult Logout()
        {
            Session["currentUser"] = null;
            return RedirectToAction("Login","Account", new { area="" });
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM data)
        {
            if (ModelState.IsValid)
            {
                Admin currentAdmin = db.Admins.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Teacher currentTeacher = db.Teachers.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
                Student currentStudent = db.Students.Where(x => x.UserName == data.UserName && x.Password == data.Password).FirstOrDefault();
                if (currentAdmin!=null || currentStudent!=null || currentTeacher!=null)
                {

                
                    if (currentAdmin != null)
                    {
                        Session["currentAdmin"] = currentAdmin;
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else if(currentTeacher != null)
                    {
                        Session["currentTeacher"] = currentTeacher;
                        return RedirectToAction("Index", "Home", new { area = "STeacher" });
                    }
                    else if(currentStudent != null)
                    {
                        Session["currentStudent"] = currentStudent;
                        return RedirectToAction("Index", "Home", new { area = "Student" });
                    }
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
    }
}