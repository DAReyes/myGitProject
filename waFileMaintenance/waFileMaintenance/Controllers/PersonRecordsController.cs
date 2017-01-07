using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using waFileMaintenance.Models;

namespace waFileMaintenance.Controllers
{
    public class PersonRecordsController : Controller
    {
        private dbFileMaintenanceEntities db = new dbFileMaintenanceEntities();

        // GET: tblPersonRecords
        public ActionResult Index()
        {
            var tblPersonRecords = db.tblPersonRecords.Include(t => t.tblGender);
            return View(tblPersonRecords.ToList());
        }

        // GET: tblPersonRecords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPersonRecord tblPersonRecord = db.tblPersonRecords.Find(id);
            if (tblPersonRecord == null)
            {
                return HttpNotFound();
            }
            return View(tblPersonRecord);
        }

        // GET: tblPersonRecords/Create
        public ActionResult Create()
        {
            ViewBag.GenderID = new SelectList(db.tblGenders, "GenderID", "Gender");
            return View();
        }

        // POST: tblPersonRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecordID,FirstName,MiddleName,LastName,DateOfBirth,GenderID,ContactNumber")] tblPersonRecord tblPersonRecord)
        {
            if (ModelState.IsValid)
            {
                db.tblPersonRecords.Add(tblPersonRecord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderID = new SelectList(db.tblGenders, "GenderID", "Gender", tblPersonRecord.GenderID);
            return View(tblPersonRecord);
        }

        // GET: tblPersonRecords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPersonRecord tblPersonRecord = db.tblPersonRecords.Find(id);
            if (tblPersonRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderID = new SelectList(db.tblGenders, "GenderID", "Gender", tblPersonRecord.GenderID);
            return View(tblPersonRecord);
        }

        // POST: tblPersonRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecordID,FirstName,MiddleName,LastName,DateOfBirth,GenderID,ContactNumber")] tblPersonRecord tblPersonRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblPersonRecord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderID = new SelectList(db.tblGenders, "GenderID", "Gender", tblPersonRecord.GenderID);
            return View(tblPersonRecord);
        }

        // GET: tblPersonRecords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblPersonRecord tblPersonRecord = db.tblPersonRecords.Find(id);
            if (tblPersonRecord == null)
            {
                return HttpNotFound();
            }
            return View(tblPersonRecord);
        }

        // POST: tblPersonRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblPersonRecord tblPersonRecord = db.tblPersonRecords.Find(id);
            db.tblPersonRecords.Remove(tblPersonRecord);
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
