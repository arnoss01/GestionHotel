using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionHotels.Models;

namespace GestionHotels.Controllers
{
    public class FacturesController : Controller
    {
        private HotelsDataBaseEntities db = new HotelsDataBaseEntities();

        // GET: Factures
        public ActionResult Index()
        {
            var facture = db.Facture.Include(f => f.reservation).Include(f => f.servicee);
            return View(facture.ToList());
        }

        // GET: Factures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Facture.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes");
            ViewBag.idSer = new SelectList(db.servicee, "idSer", "descriptions");
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFact,dateFact,idRes,idSer")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Facture.Add(facture);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", facture.idRes);
            ViewBag.idSer = new SelectList(db.servicee, "idSer", "descriptions", facture.idSer);
            return View(facture);
        }

        // GET: Factures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Facture.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", facture.idRes);
            ViewBag.idSer = new SelectList(db.servicee, "idSer", "descriptions", facture.idSer);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFact,dateFact,idRes,idSer")] Facture facture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", facture.idRes);
            ViewBag.idSer = new SelectList(db.servicee, "idSer", "descriptions", facture.idSer);
            return View(facture);
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facture facture = db.Facture.Find(id);
            if (facture == null)
            {
                return HttpNotFound();
            }
            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facture facture = db.Facture.Find(id);
            db.Facture.Remove(facture);
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
