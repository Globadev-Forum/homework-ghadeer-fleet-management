using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FleetManagement.Models;
using FleetManagement.DAL;
using System.IdentityModel.Selectors;



namespace FleetManagement.Controllers
{
    public class HomeController : Controller
    {

        private MyDbContext _context = new MyDbContext();
        public ActionResult Index()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                var duties = _context.Duties.Include(x => x.V_DriversVM.DriverId).Where(x => x.Date == DateTime.Now.Date).OrderBy(e => e.StartTime);

                //duties.OrderBy("StartTime");

                return View(duties.ToList());
            }
        }

        

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}