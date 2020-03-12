using SiteDemoRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDemoRazor.Controllers
{
    public class PersonneController : Controller
    {
        static List<Personne> personnes;

        public PersonneController()
        {
            if (personnes == null)
            {
                personnes = new List<Personne>
                {
                    new Personne{Id=1,Age=20,Nom="LUPINE", Prenom="Arthur"},
                    new Personne{Id=2,Age=25,Nom="ROGNE", Prenom="Yves"},
                    new Personne{Id=3,Age=30,Nom="PACCIO", Prenom="Oscar"},
                    new Personne{Id=4,Age=35,Nom="NICOUETTE", Prenom="Sandra"}
                };
            }
        }

        // GET: Personne
        public ActionResult Index()
        {
            return View(personnes);
        }

        // GET: Personne/Details/5
        public ActionResult Details(int id)
        {
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                return View(personne);
            }
            return RedirectToAction("Index");
        }

        // GET: Personne/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personne/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Edit/5
        public ActionResult Edit(int id)
        {
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                return View(personne);
            }
            return RedirectToAction("Index");
        }

        // POST: Personne/Edit/5
        [HttpPost]
        public ActionResult Edit(Personne personne)
        {
            try
            {
                var personneDb = personnes.FirstOrDefault(p => p.Id == personne.Id);
                personneDb.Nom = personne.Nom;
                personneDb.Prenom = personne.Prenom;
                personneDb.Age = personne.Age;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personne/Delete/5
        public ActionResult Delete(int id)
        {
            var personne = personnes.FirstOrDefault(p => p.Id == id);
            if (personne != null)
            {
                return View(personne);
            }
            return RedirectToAction("Index");
        }

        // POST: Personne/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var personne = personnes.FirstOrDefault(p => p.Id == id);
                personnes.Remove(personne);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
