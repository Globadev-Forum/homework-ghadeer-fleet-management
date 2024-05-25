using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FleetManagement.DAL;
using FleetManagement.Models; 

namespace FleetManagement.Controllers
{
    public class LoginController : Controller
    {

        private MyDbContext _context = new MyDbContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserViewModel s)
        {
            if (ModelState.IsValid == true)
            {
                var credintials = _context.Users.Where(model => model.UserName == s.UserName && model.Password == s.Password).FirstOrDefault();
                if (credintials == null)
                {
                    ViewBag.ErrorMessage = "Login Failed";
                    return View();
                }
                else
                {
                     Session["username"] = credintials.UserName;
                    Session["IsAdmin"] = credintials.IsAdmin; 
                    RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Clear ();
            return RedirectToAction("Index", "Login");
        }

    }
}