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
    public class ChatService : IChatRepository<Chat>
    {
        private IChatRepository<gl.Chat> _rep;

        public ChatService() { _rep = new ChatRepository(); }

        public bool Activer(int id)
        {
            return _rep.Activer(id);
            throw new NotImplementedException();
        }

        public int Creer(Chat e)
        {
            return _rep.Creer(e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            return _rep.Desactiver(id);
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> Donner()
        {
            return _rep.Donner().Select(j=>j.VersClient());
            throw new NotImplementedException();
        }

        public Chat Donner(int id)
        {
            return _rep.Donner(id).VersClient();
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> Donner(DateTime aPartirDe)
        {
            return _rep.Donner(aPartirDe).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> Donner(int idUtilisateur, DateTime? aPartirDe = null)
        {
            return _rep.Donner(idUtilisateur, aPartirDe).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        /*inutile*/
        public IEnumerable<Chat> Donner(IEnumerable<int> ie, string[] options = null)
        {
            return _rep.Donner(ie, options).Select(j => j.VersClient());
            throw new NotImplementedException();
        }
    }
}
