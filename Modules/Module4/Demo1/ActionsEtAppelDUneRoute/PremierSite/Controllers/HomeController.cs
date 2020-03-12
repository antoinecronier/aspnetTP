using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PremierSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Bonjour()
        {
            return View();
        }

        [Route("Bienvenue/{nom}")]
        public ActionResult Welcome(string nom)
        {
            ViewBag.Nom = nom;
            return View();
        }
    }
}