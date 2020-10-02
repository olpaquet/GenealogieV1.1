using Genealogie.API.Autentification;
using Genealogie.API.Conversion;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
/*using Genealogie.DAL.Global.Repository;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genealogie.API.Controllers
{
    [AutBase("-")]
    public class ConversationController : ApiController /*, IConversationRepository<Conversation>*/
    {
        [HttpPost]
        public int Creer(Conversation e)
        {
            return new ConversationService().Creer(e.VersClient());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Detruire(int id)
        {
            return new ConversationService().Detruire(id);
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<Conversation> Donner()
        {
            return new ConversationService().Donner().Select(j => j.VersAPI());
            throw new NotImplementedException();
        }
        [HttpGet]
        public Conversation Donner(int id)
        {
            return new ConversationService().Donner(id).VersAPI();
            throw new NotImplementedException();
        }
        [HttpGet]
        public IEnumerable<Conversation> DonnerParEmetteur(int id)
        {
            return new ConversationService().DonnerParEmetteur(id).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Modifier(int id, Conversation e)
        {
            return new ConversationService().Modifier(id, e.VersClient());
            throw new NotImplementedException();
        }

        [HttpDelete]
        public bool Supprimer(int id)
        {
            return new ConversationService().Supprimer(id);
            throw new NotImplementedException();
        }
    }
}
