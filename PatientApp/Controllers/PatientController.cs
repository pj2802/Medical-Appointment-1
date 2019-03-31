using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PatientApp.Models;
using System.Net;

namespace PatientApp.Controllers
{
    public class PatientController : Controller
    {
        DataContext db = new DataContext();
        // GET: Patient
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.CurrentDateTime = DateTime.Now;
            var data= db.Patients.ToList();
           // List<Patients> patients = db.Patients.ToList();
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(string PatientName, Patients patients)
        {
            var data = db.Patients.ToList().Where(p => p.PatientName.StartsWith(PatientName));
            // List<Patients> patients = db.Patients.ToList();
            return View(data);
        }


        public ActionResult Create()
        {
           return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,PatientName,Gender,Age,MaritalStatus,MobileNumber,Address")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patients);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(patients);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,PatientName,Gender,Age,MaritalStatus,MobileNumber,Address")] Patients patients)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patients).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patients);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }



        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patients patients = db.Patients.Find(id);
            if (patients == null)
            {
                return HttpNotFound();
            }
            return View(patients);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patients patients = db.Patients.Find(id);
            db.Patients.Remove(patients);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}