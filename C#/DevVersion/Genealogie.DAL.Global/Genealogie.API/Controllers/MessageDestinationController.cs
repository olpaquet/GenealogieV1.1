using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Genealogie.API.Conversion;

//using Genealogie.DAL.Global.Repository;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;

namespace Genealogie.API.Controllers
{
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

        public IEnumerable<MessageDestination> Donner()
        {
            return new MessageDestinationService().Donner().Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        public MessageDestination Donner(int id, int id2)
        {
            return new MessageDestinationService().Donner(id, id2).VersAPI();
            throw new NotImplementedException();
        }

        public bool Lire(int id, int id2)
        {
            return new MessageDestinationService().Lire(id, id2);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, int id2, MessageDestination e)
        {
            return new MessageDestinationService().Modifier(id, id2, e.VersClient());
            throw new NotImplementedException();
        }

        public bool Supprimer(int id, int id2)
        {
            return new MessageDestinationService().Supprimer(id, id2);
            throw new NotImplementedException();
        }
    }
}
