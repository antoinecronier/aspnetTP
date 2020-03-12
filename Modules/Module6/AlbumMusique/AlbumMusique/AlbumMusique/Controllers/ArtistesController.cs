using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlbumMusique.Models;
using BO;

namespace AlbumMusique.Controllers
{
    public class ArtistesController : Controller
    {
        private Context db = new Context();

        // GET: Artistes
        public ActionResult Index()
        {
            return View(db.Artistes.ToList());
        }

        // GET: Artistes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiste artiste = db.Artistes.Find(id);
            if (artiste == null)
            {
                return HttpNotFound();
            }
            return View(artiste);
        }

        // GET: Artistes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artistes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom")] Artiste artiste)
        {
            if (ModelState.IsValid)
            {
                // db.Artistes.Add(artiste);
                db.Entry(artiste).State = EntityState.Added;
                db.SaveChanges();
                var state = db.Entry(artiste).State;
                return RedirectToAction("Index");
            }

            return View(artiste);
        }

        // GET: Artistes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiste artiste = db.Artistes.Find(id);
            if (artiste == null)
            {
                return HttpNotFound();
            }
            return View(artiste);
        }

        // POST: Artistes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom")] Artiste artiste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artiste).State = EntityState.Modified;
                db.SaveChanges();
                var state = db.Entry(artiste).State;
                return RedirectToAction("Index");
            }
            return View(artiste);
        }

        // GET: Artistes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artiste artiste = db.Artistes.Find(id);
            if (artiste == null)
            {
                return HttpNotFound();
            }
            return View(artiste);
        }

        // POST: Artistes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artiste artiste = db.Artistes.Find(id);
            db.Entry(artiste).State = EntityState.Deleted;
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
