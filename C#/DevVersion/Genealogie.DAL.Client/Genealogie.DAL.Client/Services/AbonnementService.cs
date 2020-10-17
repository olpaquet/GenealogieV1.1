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
    public class AbonnementService : IAbonnementRepository<Abonnement>
    {
        private IAbonnementRepository<gl.Abonnement> _rep;

        public AbonnementService() { this._rep = new AbonnementRepository(); }

        public bool Activer(int id)
        {
            return _rep.Activer(id);
            throw new NotImplementedException();
        }

        public int Creer(Abonnement e)
        {
            return _rep.Creer(e.VersGlobal());
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            return _rep.Desactiver(id);
            throw new NotImplementedException();
        }

        public IEnumerable<Abonnement> Donner()
        {
            return _rep.Donner().Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public Abonnement Donner(int id)
        {
            gl.Abonnement x = _rep.Donner(id);
            Abonnement xx = x.VersClient();
            return xx;
            throw new NotImplementedException();
        }

        public IEnumerable<Abonnement> Donner(IEnumerable<int> ie, string[] options = null)
        {
            return _rep.Donner(ie, options).Select(j=>j.VersClient());
            throw new NotImplementedException();
        }

        public int? DonnerParNom(string nom)
        {
            return _rep.DonnerParNom(nom);
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return _rep.EstUtilisee(id, options);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Abonnement e)
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
