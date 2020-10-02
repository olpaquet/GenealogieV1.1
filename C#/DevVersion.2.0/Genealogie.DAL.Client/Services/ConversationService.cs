using Genealogie.DAL.Client.Modeles;
using gl = Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Client.Conversion;
using System.Linq;

namespace Genealogie.DAL.Client.Services
{
    public class ConversationService : IConversationRepository<Conversation>
    {

        private IConversationRepository<gl.Conversation> _rep;

        public ConversationService() { this._rep = new ConversationRepository(); }

        public int Creer(Conversation e)
        {
            return _rep.Creer(e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Detruire(int id)
        {
            return _rep.Detruire(id);
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> Donner()
        {
            return _rep.Donner().Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public Conversation Donner(int id)
        {
            return _rep.Donner(id).VersClient();
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> DonnerParEmetteur(int id)
        {
            return _rep.DonnerParEmetteur(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return _rep.EstUtilisee(id, options);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Conversation e)
        {
            return _rep.Modifier(id, e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Supprimer(int id)
        {
            return _rep.Supprimer(id);
            throw new NotImplementedException();
        }
    }
}
