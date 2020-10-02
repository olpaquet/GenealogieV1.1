using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Genealogie.API.Autentification;
using Genealogie.API.Conversion;

//using Genealogie.DAL.Global.Repository;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;

namespace Genealogie.API.Controllers
{
    [AutBase("-")]
    public class MessageDestinationController : ApiController /*, IMessageDestinationRepository<MessageDestination>*/
    {
        [HttpPost]
        public bool Creer(int id, int id2, MessageDestination e)
        {
            return new MessageDestinationService().Creer(id, id2, e.VersClient());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Detruire(int id, int id2)
        {
            return new MessageDestinationService().Detruire(id, id2);
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<MessageDestination> DonnerPourConversation(int id)
        {
            return new MessageDestinationService().DonnerPourConversation(id).Select(k => k.VersAPI());
        }
        [HttpGet]
        public IEnumerable<MessageDestination> Donner()
        {
            return new MessageDestinationService().Donner().Select(j => j.VersAPI());
            throw new NotImplementedException();
        }
        [HttpGet]
        public MessageDestination Donner(int id, int id2)
        {
            return new MessageDestinationService().Donner(id, id2).VersAPI();
            throw new NotImplementedException();
        }
        [HttpGet]
        public bool Lire(int id, int id2)
        {
            return new MessageDestinationService().Lire(id, id2);
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Modifier(int id, int id2, MessageDestination e)
        {
            return new MessageDestinationService().Modifier(id, id2, e.VersClient());
            throw new NotImplementedException();
        }

        [HttpDelete]
        public bool Supprimer(int id, int id2)
        {
            return new MessageDestinationService().Supprimer(id, id2);
            throw new NotImplementedException();
        }

        [HttpGet]
        public bool EstLu(int id, int id2)
        {
            return new MessageDestinationService().EstLu(id, id2);
        }


    }
}
