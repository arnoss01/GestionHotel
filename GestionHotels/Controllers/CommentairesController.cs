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
    public class CommentairesController : Controller
    {
        private HotelsDataBaseEntities db = new HotelsDataBaseEntities();

        // GET: Commentaires
        public ActionResult Index()
        {
            var commentaire = db.Commentaire.Include(c => c.Client).Include(c => c.Hotel);
            return View(commentaire.ToList());
        }

        // GET: Commentaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = db.Commentaire.Find(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // GET: Commentaires/Create
        public ActionResult Create()
        {
            ViewBag.idCl = new SelectList(db.Client, "idCl", "nom");
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse");
            return View();
        }

        // POST: Commentaires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCl,idHot,comm")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                db.Commentaire.Add(commentaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCl = new SelectList(db.Client, "idCl", "nom", commentaire.idCl);
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", commentaire.idHot);
            return View(commentaire);
        }

        // GET: Commentaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = db.Commentaire.Find(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCl = new SelectList(db.Client, "idCl", "nom", commentaire.idCl);
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", commentaire.idHot);
            return View(commentaire);
        }

        // POST: Commentaires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCl,idHot,comm")] Commentaire commentaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commentaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCl = new SelectList(db.Client, "idCl", "nom", commentaire.idCl);
            ViewBag.idHot = new SelectList(db.Hotel, "idHot", "adresse", commentaire.idHot);
            return View(commentaire);
        }

        // GET: Commentaires/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commentaire commentaire = db.Commentaire.Find(id);
            if (commentaire == null)
            {
                return HttpNotFound();
            }
            return View(commentaire);
        }

        // POST: Commentaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commentaire commentaire = db.Commentaire.Find(id);
            db.Commentaire.Remove(commentaire);
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
