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
using System.Web.UI.WebControls;



namespace FleetManagement.Controllers
{
    public class DutiesController : Controller
    {
        private MyDbContext _context = new MyDbContext();

        
       public ActionResult Index(string SearchString, string sortBy)
        {
            var duties = _context.Duties.Include(i => i.V_DriversVM.DriverId);

            //Search Functionality
            if (!String.IsNullOrEmpty (SearchString ))
            {
                duties = duties.Where(n=> n.Date.ToString () == SearchString+ " 00:00:00.0000000") ;
                ViewData["SearchString"] = SearchString;
            }

            ViewData["DateSortParam"] = string.IsNullOrEmpty(sortBy) ? "Date_desc" : "";
            ViewData["StartTimeSortParam"] = string.IsNullOrEmpty(sortBy) ? "StartTime_desc" : "";
            ViewData["EndTimeSortParam"] = string.IsNullOrEmpty(sortBy) ? "EndTime_desc" : "";
            ViewData["DriverSortParam"] = string.IsNullOrEmpty(sortBy) ? "Driver_desc" : "";


            //Sorting Functionality
            switch (sortBy )
            {
                case "Date_desc":
                    duties = duties.OrderByDescending(e => e.Date); 
                    break;

                case "StartTime_desc":
                    duties = duties.OrderByDescending(e => e.Date).ThenByDescending(a=> a.StartTime) ; 
                    break;
                
                case "StartTime_asc":
                    duties = duties.OrderBy(e => e.Date).ThenBy(e => e.StartTime); 
                    break;

                case "EndTime_desc":
                    duties = duties.OrderByDescending(e => e.Date).ThenByDescending(e => e.EndTime); 
                    break;

                case "EndTime_asc":
                    duties = duties.OrderBy(e => e.Date).ThenBy(e => e.EndTime); 
                    break;

                case "Driver_desc":
                    duties = duties.OrderByDescending(e => e.Date).ThenByDescending(e => e.V_DriversVM.Name); //desc order
                    break;

                case "Driver_asc":
                    duties = duties.OrderBy(e => e.Date).ThenBy(e => e.V_DriversVM.Name); //desc order
                    break;

                default:
                    duties = duties.OrderBy(e => e.Date); //ascending order
                    break;

            }

            return View(duties.ToList ());
        }

       // GET: /Duties/Create
        public ActionResult Create()
        {

            ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name");
            return View();
        }

        // POST: /Duties/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DutyId,Desc,Date, StartTime, EndTime,DriverId")] DutyViewModel duties)
        {
            if (ModelState.IsValid)
            {
                _context.Duties.Add(duties);
                if (duties.StartTime >= duties.EndTime)
                {
                    TempData["errormessage"] = "Start date should be less than end date";
                }
                else if (TimeOverlap(0, duties.Date, duties.StartTime, duties.EndTime, duties.DriverId) == true )
                {
                    TempData["errormessage"] = "There's overlap in time range with another duty";
                }
                else
                {
                    _context.SaveChanges();
                  //  NewHeadlessEmail("omarighadeer81@gmail.com", "eewc gccg inxt enij", duties.Drivers.Email, "New Task", "You have a new task assigned to you!");
                    NewHeadlessEmail("omarighadeer81@gmail.com", "eewc gccg inxt enij", "omarighadeer81@gmail.com", "New Task", "You have a new task assigned to you!");

                    return RedirectToAction("Index");
                }
            }

            ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name", duties.DriverId);
            return View(duties);
        }

        public void NewHeadlessEmail(string fromEmail, string password, string toAddress, string subject, string body)
        {
            using (System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage())
            {
                myMail.From = new MailAddress(fromEmail);
                myMail.To.Add(toAddress);
                myMail.Subject = subject;
                myMail.IsBodyHtml = true;
                myMail.Body = body;

                using (System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    s.DeliveryMethod = SmtpDeliveryMethod.Network;
                    s.UseDefaultCredentials = false;
                    s.Credentials = new System.Net.NetworkCredential(myMail.From.ToString(), password);
                    s.EnableSsl = true;
                    s.Send(myMail);
                }
            }
        }

        public bool TimeOverlap(int DutyId, DateTime? DutyDate, DateTime? StartTime1, DateTime? EndTime1, int PassedDriverId)
        {
            bool Overlap = false;

            if (DutyId == 0) //new
            {
                var availableduties = _context.Duties.Where(m => m.Date == DutyDate).Where(m => m.DriverId == PassedDriverId).ToList();
                for (int i = 0; i < availableduties.Count; i++)
                {
                    //startTime1 <= endTime2 && startTime2 <= endTime1
                    if ((StartTime1 <= availableduties[i].EndTime) && (availableduties[i].StartTime <= EndTime1))
                    {
                        Overlap = true;
                    }
                    else
                        return (false);
                }
            }
            else
            {
                var availableduties = _context.Duties.Where(m => m.Date == DutyDate).Where(m => m.DriverId == PassedDriverId).Where (m=> m.DutyId != DutyId).ToList();
                for (int i = 0; i < availableduties.Count; i++)
                {
                    //startTime1 <= endTime2 && startTime2 <= endTime1
                    if ((StartTime1 <= availableduties[i].EndTime) && (availableduties[i].StartTime <= EndTime1))
                    {
                        Overlap = true;
                    }
                    else
                        return (false);
                }
            }
            
            return Overlap;
        }
        
        // GET: /Duty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DutyViewModel Duty = _context.Duties.Find(id);
            if (Duty == null)
            {
                return HttpNotFound();
            }

            ViewBag.DriverId = new SelectList(_context.Drivers , "DriverId", "Name", Duty.DriverId);
            return View(Duty);
        }

        // POST: /Duty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DutyId,Desc,Date,StartTime,EndTime,DriverId")] DutyViewModel duties)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(duties).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                if (duties.StartTime >= duties.EndTime)
                {
                    TempData["errormessage"] = "Start date should be less than end date";
                }
                else if (TimeOverlap(duties.DutyId ,duties.Date, duties.StartTime, duties.EndTime, duties.DriverId) == true)
                {
                    TempData["errormessage"] = "There's overlap in time range with another duty";
                }
                else
                {
                    _context.SaveChanges();
                    TempData["successmessage"] = "Duty updated sucessfully!";
                    NewHeadlessEmail("omarighadeer81@gmail.com", "eewc gccg inxt enij", "omarighadeer81@gmail.com", "Updated Task", "You have an update on a task assigned to you!");
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DriverId = new SelectList(_context.Drivers, "DriverId", "Name", duties.DriverId);
            return View(duties);
        }

        // GET: /Duty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DutyViewModel duties = _context.Duties.Find(id);
            if (duties == null)
            {
                return HttpNotFound();
            }
            return View(duties);
        }

        // POST: /Duty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DutyViewModel duties = _context.Duties.Find(id);
            _context.Duties.Remove(duties);
            _context.SaveChanges();
            TempData["successmessage"] = "Duty deleted sucessfully!";
            return RedirectToAction("Index");
        }

       

    }
}