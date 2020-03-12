using SiteDemoRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteDemoRazor.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.Message = "Ceci est un message porté par le ViewBag";
            TempData["Message"] = "Ceci est un message porté par le TempData";

            var vm = new MessageVM { Message = "Ceci est un message porté par le ViewModel" };

            return View(vm);
        }
    }
}