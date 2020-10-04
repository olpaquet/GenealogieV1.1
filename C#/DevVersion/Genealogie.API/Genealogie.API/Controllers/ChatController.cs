using Genealogie.API.Conversion;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace Genealogie.API.Controllers
{
    public class ChatController : ApiController
    {
        [HttpPut]
        public bool Activer(int id)
        {
            return new ChatService().Activer(id);
            throw new NotImplementedException();
        }
        [HttpPost]
        public int Creer(Chat e)
        {
            return new ChatService().Creer(e.VersClient());
            throw new NotImplementedException();
        }
        [HttpPut]
        public bool Desactiver(int id)
        {
            return new ChatService().Desactiver(id);
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public Chat Donner(int id)
        {
            return new ChatService().Donner(id).VersAPI();
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<Chat> Donner()
        {
            /*if (e.idUtilisateur == null & e.aPartirDe == null) return new ChatService().Donner().Select(j => j.VersAPI());
            if (e.idUtilisateur == null) return new ChatService().Donner((DateTime)e.aPartirDe).Select(j => j.VersAPI());*/
            return new ChatService().Donner(DateTime.Now.AddMonths(-1)).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        /*
        public IEnumerable<Chat> Donner(IEnumerable<int> ie, string[] options = null)
        {
            return new ChatService().Donner(ie, options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }*/

        
    }
}