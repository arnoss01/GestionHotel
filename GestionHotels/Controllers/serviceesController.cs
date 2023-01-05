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
    public class serviceesController : Controller
    {
        private HotelsDataBaseEntities db = new HotelsDataBaseEntities();

        // GET: servicees
        public ActionResult Index()
        {
            return View(db.servicee.ToList());
        }

        // GET: servicees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicee servicee = db.servicee.Find(id);
            if (servicee == null)
            {
                return HttpNotFound();
            }
            return View(servicee);
        }

        // GET: servicees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: servicees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idSer,descriptions,prix")] servicee servicee)
        {
            if (ModelState.IsValid)
            {
                db.servicee.Add(servicee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicee);
        }

        // GET: servicees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicee servicee = db.servicee.Find(id);
            if (servicee == null)
            {
                return HttpNotFound();
            }
            return View(servicee);
        }

        // POST: servicees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idSer,descriptions,prix")] servicee servicee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicee);
        }

        // GET: servicees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicee servicee = db.servicee.Find(id);
            if (servicee == null)
            {
                return HttpNotFound();
            }
            return View(servicee);
        }

        // POST: servicees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicee servicee = db.servicee.Find(id);
            db.servicee.Remove(servicee);
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
