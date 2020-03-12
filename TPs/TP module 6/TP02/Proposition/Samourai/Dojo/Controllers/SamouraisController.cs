using System.Linq;
using System.Net;
using System.Web.Mvc;
using BO;
using Dojo.Models;

namespace Dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private Context db = new Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            // cration du ViewModel nécessaire pour porter la lsite des armes et l'id de l'arme choisie en plus du samouraï
            var vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                // on vérifie qu'une arme ai été choisie
                if (vm.IdSelectedArme.HasValue)
                {
                    // on assigne l'arme dont l'Id à été choisi au samouraï
                    vm.Samourai.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.IdSelectedArme.Value);
                }

                // On ajoute le nouveau samouraï au DbSet, puis on enregistre les changements en base
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            var vm = new SamouraiVM();
            vm.Armes = db.Armes.ToList();
            vm.Samourai = samourai;

            if (samourai.Arme != null)
            {
                // Si le samourai avait une arme, on affecte l'Id de cette arme à notre VIewModel, ansi elle sera préselectionnée dans notre liste d'armes 
                vm.IdSelectedArme = samourai.Arme.Id;
            }
            return View(vm);
        }

        // POST: Samourais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                // On récupère le samouraï en base correspondant à cet Id, puis on met ses propriétés à jour à partie des valeurs du ViewModel
                var samouraidb = db.Samourais.Find(vm.Samourai.Id);
                samouraidb.Force = vm.Samourai.Force;
                samouraidb.Nom = vm.Samourai.Nom;
                samouraidb.Arme = null;
                if (vm.IdSelectedArme.HasValue)
                {
                    samouraidb.Arme = db.Armes.FirstOrDefault(a => a.Id == vm.IdSelectedArme.Value);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = db.Armes.ToList();
            return View(vm);
        }

        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
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
