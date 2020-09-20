using Genealogie.DAL.Client.Modeles;
using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Global.Repository;
using gl = Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Client.Conversion;
using System.Linq;

namespace Genealogie.DAL.Client.Services
{
    public class PersonneService : IPersonneRepository<Personne>
    {

        private IPersonneRepository<gl.Personne> _rep;

        public PersonneService() { this._rep = new PersonneRepository(); }

        public int Creer(Personne e)
        {
            return _rep.Creer(e.VersGlobal());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> Donner(int idArbre)
        {
            return _rep.Donner(idArbre).Select(q => q.VersClient());
            throw new NotImplementedException();
        }

        public Personne Donner(int idArbre, int idPersonne)
        {
            return _rep.Donner(idArbre, idPersonne).VersClient();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            return _rep.DonnerEnfants(id).Select(m => m.VersClient());
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Personne e)
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
