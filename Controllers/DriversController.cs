using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FleetManagement.DAL;
using FleetManagement.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Net;



namespace FleetManagement.Controllers
{
    public class DriversController : Controller
    {
        // GET: Drivers
        private MyDbContext _context = new MyDbContext();

       
        [HttpGet]

        public ActionResult Index()
        {
            try
            {
              
                return View(_context.Drivers.ToList());
            }
            catch (NullReferenceException)  // could happen if POST is interrupted
            {
                // perhaps log a warning here
                return null;
            }

           
        }

        // GET: /Driver/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: /Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverId,Name,Mobile,Email")] DriverViewModel driver)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Drivers.Add(driver);
                    _context.SaveChanges();
                    TempData["successmessage"] = "Driver created sucessfully!";
                    return RedirectToAction("Index");

                   
                }
                else
                {
                    TempData["errormessage"] = "Model data is not valid.";
                    return View(driver);
                }
                
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DriverViewModel driver = _context.Drivers.Find(id);
                if (driver == null)
                {
                    return HttpNotFound();
                }
                return View(driver);
            }
            catch (NullReferenceException)  // could happen if POST is interrupted
            {
                // perhaps log a warning here
                return null;
            }

        }


        // GET: /Driver/Edit/5
        public ActionResult Edit(int? id)
        {
            try

            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                DriverViewModel driver = _context.Drivers.Find(id);
                if (driver == null)
                {
                    return HttpNotFound();
                }
                return View(driver);

            }
            catch (NullReferenceException)  // could happen if POST is interrupted
            {
                // perhaps log a warning here
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverId,Name,Mobile,Email")] DriverViewModel driver)
        {
            try
            { 
                if (ModelState.IsValid)
                {
                    _context.Entry(driver).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    TempData["successmessage"] = "Driver edited sucessfully!";
                    return RedirectToAction("Index");
                }
              
                else
                {
                    TempData["errormessage"] = "Model data is not valid.";
                    return View(driver);
                }

            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
            }
        }

        // GET: /Driver/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DriverViewModel driver = _context.Drivers.Find(id);
            if (driver == null)
            {
                return HttpNotFound();
            }
            return View(driver);
        }

        // POST: /Driver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            { 
                DriverViewModel driver = _context.Drivers.Find(id);
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
                TempData["successmessage"] = "Driver deleted sucessfully!";
                return RedirectToAction("Index");
               

            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}