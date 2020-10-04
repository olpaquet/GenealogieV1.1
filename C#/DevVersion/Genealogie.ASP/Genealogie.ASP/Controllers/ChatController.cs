using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    [ConnecteAut]
    public class ChatController : Controller
    {
        // GET: Chat
        [HttpGet]
        public ActionResult Miauler()
        {
            DateTime apartirde = DateTime.Now.AddDays(-60);
            IEnumerable<Chat> ch = new ChatServiceAPI().Donner(null, apartirde);

            IEnumerable<ChatIndex> ci = ch.Select(j => new ChatIndex(j, apartirde));
            return View(ci);
            
        }
    }
}