using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Chat.Models;

namespace TP_Chat.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats;
        public List<Chat> Chats => chats ?? (chats = Chat.GetMeuteDeChats());

        // GET: Chat
        public ActionResult Index()
        {
            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            var chat = Chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var chat = Chats.FirstOrDefault(c => c.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var chat = Chats.FirstOrDefault(c => c.Id == id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}