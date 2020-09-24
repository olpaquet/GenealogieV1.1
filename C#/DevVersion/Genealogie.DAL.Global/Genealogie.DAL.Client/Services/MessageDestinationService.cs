using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Client.Modeles;
using Genealogie.DAL.Global.Repository;
using gl = Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Client.Conversion;
using System.Linq;

namespace Genealogie.DAL.Client.Services
{
    public class MessageDestinationService : IMessageDestinationRepository<MessageDestination>
    {

        private IMessageDestinationRepository<gl.MessageDestination> _rep;

        public MessageDestinationService() { this._rep = new MessageDestinationRepository(); }

        public bool Creer(int id1, int id2, MessageDestination e)
        {
            return _rep.Creer(id1, id2, e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Detruire(int idConversation, int idDestinataire)
        {
            return _rep.Detruire(idConversation, idDestinataire);
            throw new NotImplementedException();
        }

        public IEnumerable<MessageDestination> Donner()
        {
            return _rep.Donner().Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public MessageDestination Donner(int id1, int id2)
        {
            return _rep.Donner(id1, id2).VersClient();
            throw new NotImplementedException();
        }

        public bool Lire(int idConversation, int idDestinataire)
        {
            return _rep.Lire(idConversation, idDestinataire);
            throw new NotImplementedException();
        }

        public bool Modifier(int id1, int id2, MessageDestination e)
        {
            return _rep.Modifier(id1, id2, e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Supprimer(int id1, int id2)
        {
            return _rep.Supprimer(id1, id2);
            throw new NotImplementedException();
        }
    }
}
