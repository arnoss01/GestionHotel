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
    public class chambresController : Controller
    {
        private HotelsDataBaseEntities db = new HotelsDataBaseEntities();

        // GET: chambres
        public ActionResult Index()
        {
            var chambre = db.chambre.Include(c => c.Hotel).Include(c => c.reservation);
            return View(chambre.ToList());
        }

        // GET: chambres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chambre chambre = db.chambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // GET: chambres/Create
        public ActionResult Create()
        {
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse");
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes");
            return View();
        }

        // POST: chambres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numChamb,etat,idHot,idRes")] chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.chambre.Add(chambre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", chambre.idHot);
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", chambre.idRes);
            return View(chambre);
        }

        // GET: chambres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chambre chambre = db.chambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", chambre.idHot);
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", chambre.idRes);
            return View(chambre);
        }

        // POST: chambres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numChamb,etat,idHot,idRes")] chambre chambre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chambre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", chambre.idHot);
            ViewBag.idRes = new SelectList(db.reservation, "idRes", "idRes", chambre.idRes);
            return View(chambre);
        }

        // GET: chambres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chambre chambre = db.chambre.Find(id);
            if (chambre == null)
            {
                return HttpNotFound();
            }
            return View(chambre);
        }

        // POST: chambres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chambre chambre = db.chambre.Find(id);
            db.chambre.Remove(chambre);
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
