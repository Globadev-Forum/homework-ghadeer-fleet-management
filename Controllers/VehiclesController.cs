using FleetManagement.DAL;
using FleetManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;
using FreeSql.Internal;
using System.Net;
using System.Data.SqlClient;
using System.Net.Mail;

namespace FleetManagement.Controllers
{
    public class VehiclesController : Controller
    {
        // GET: Vehicles
        private MyDbContext _context = new MyDbContext();

        public ActionResult Index()
        {
            var vehicles = _context.Vehicles.Include(i => i.DriverId);
            return View(vehicles.ToList());
        }
       
        // GET: /Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name");
            return View();
        }

        // POST: /Driver/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VehicleId,Vehicle_Desc,Vehicle_Plate_No,Vehicle_Reg_Date,Vehicle_Exp_Reg_Date,Vehicle_Ins_PolicyNo,DriverId")] VehicleViewModel vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Vehicles.Add(vehicle);
                    _context.SaveChanges();
                    TempData["successmessage"] = "Vehicle created sucessfully!";
                    ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name", vehicle.DriverId);
                    return RedirectToAction("Index");


                }
                else
                {
                    TempData["errormessage"] = "Model data is not valid.";
                    return View(vehicle);
                }
                
            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
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
                VehicleViewModel vehicle = _context.Vehicles.Find(id);
                if (vehicle == null)
                {
                    return HttpNotFound();
                }
                ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name", vehicle.DriverId);
                return View(vehicle);

            }
            catch (NullReferenceException)  // could happen if POST is interrupted
            {
                // perhaps log a warning here
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VehicleId,Vehicle_Desc,Vehicle_Plate_No,Vehicle_Reg_Date,Vehicle_Exp_Reg_Date,Vehicle_Ins_PolicyNo,DriverId")] VehicleViewModel vehicle)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(vehicle).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    TempData["successmessage"] = "Vehicle edited sucessfully!";
                    ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name", vehicle.DriverId);
                    return RedirectToAction("Index");
                }

                else
                {
                    TempData["errormessage"] = "Model data is not valid.";
                    return View(vehicle);
                }

            }
            catch (Exception ex)
            {

                TempData["errormessage"] = ex.Message;
                return View();
            }
        }

        // GET: /Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleViewModel vehicle = _context.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: /vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                VehicleViewModel vehicle = _context.Vehicles.Find(id);
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
                TempData["successmessage"] = "Vehicle deleted sucessfully!";
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