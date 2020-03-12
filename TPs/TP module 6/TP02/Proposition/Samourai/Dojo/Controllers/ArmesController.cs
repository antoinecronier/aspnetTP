using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BO;
using Dojo.Models;

namespace Dojo.Controllers
{
    public class ArmesController : Controller
    {
        private Context db = new Context();

        // GET: Armes
        public ActionResult Index()
        {
            return View(db.Armes.ToList());
        }

        // GET: Armes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // GET: Armes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Armes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Arme arme)
        {
            if (ModelState.IsValid)
            {
                db.Armes.Add(arme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arme);
        }

        // GET: Armes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }
            return View(arme);
        }

        // POST: Armes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Arme arme)
        {
            if (ModelState.IsValid)
            {
                var armeDb = db.Armes.Find(arme.Id);
                armeDb.Nom = arme.Nom;
                armeDb.Degats = arme.Degats;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arme);
        }

        // GET: Armes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arme arme = db.Armes.Find(id);
            if (arme == null)
            {
                return HttpNotFound();
            }

            try
            {
                // on récupère tous les samouraïs qui possèdent cette arme
                var samourais = db.Samourais.Where(s => s.Arme.Id == id).ToList();
                if (samourais.Any())
                {
                    // si il existe des samourais associés à l'arme, on renvoi la liste de leurs noms à l'aide du Viewbag
                    ViewBag.Samourais = samourais.Select(s => s.Nom).ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return View(arme);
        }

        // POST: Armes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Arme arme = db.Armes.Find(id);

                // on récupère tous les samouraïs qui possèdent cette arme
                var samourais = db.Samourais.Where(s => s.Arme.Id == id).ToList();
                foreach (var samourai in samourais)
                {
                    // on supprimme la liaison entre le samouraï et l'arme
                    samourai.Arme = null;
                }
                db.Armes.Remove(arme);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

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
