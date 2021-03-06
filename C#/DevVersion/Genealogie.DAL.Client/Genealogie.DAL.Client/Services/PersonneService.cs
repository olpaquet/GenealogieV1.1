﻿using Genealogie.DAL.Client.Modeles;
using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Global.Repository;
using gl = Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Client.Conversion;
using System.Linq;
using Services;
using System.Security.Cryptography.X509Certificates;

namespace Genealogie.DAL.Client.Services
{
    public class PersonneService : IPersonneRepository<Personne,Recherche,Descendant>
    {

        private IPersonneRepository<gl.Personne, Recherche,gl.Descendant> _rep;

        public PersonneService() { this._rep = new PersonneRepository(); }

        public int Creer(Personne e)
        {
            return _rep.Creer(e.VersGlobal());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> Donner()
        {
            return _rep.Donner().Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public Personne Donner(int id)
        {
            return _rep.Donner(id).VersClient();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            return _rep.DonnerEnfants(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public Personne DonnerMere(int id)
        {
            return _rep.DonnerMere(id).VersClient();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerPourArbre(int idArbre)
        {
            return _rep.DonnerPourArbre(idArbre).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(int id)
        {
            return _rep.DonnerParenteesDirectesPossibles(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public Personne DonnerPere(int id)
        {
            return _rep.DonnerPere(id).VersClient();
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return _rep.EstUtilisee(id, options);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Personne e)
        {
            return _rep.Modifier(id, e.VersGlobal());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> Rechercher(Recherche e)
        {
            return _rep.Rechercher(e).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public bool Supprimer(int id)
        {
            return _rep.Supprimer(id);
            throw new NotImplementedException();
        }

        public bool AjouterEnfant(int id, int idEnfant)
        {
            return _rep.AjouterEnfant(id, idEnfant);
            throw new NotImplementedException();
        }

        public bool SupprimerEnfant(int id, int idEnfant)
        {
            return _rep.SupprimerEnfant(id, idEnfant);
            throw new NotImplementedException();
        }

        public bool SupprimerPere(int id)
        {
            return _rep.SupprimerPere(id);
            throw new NotImplementedException();
        }

        public bool SupprimerMere(int id)
        {
            return _rep.SupprimerMere(id);
            throw new NotImplementedException();
        }

        public bool AjouterParent(int id, int idParent)
        {
            return _rep.AjouterParent(id, idParent);
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int idPere, int idMere)
        {
            var x = _rep.DonnerEnfants(idPere, idMere);
            return x==null?null:x.Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfantsSansMere(int idPere)
        {
            var x = _rep.DonnerEnfantsSansMere(idPere);
            return x == null ? null : x.Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfantsSansPere(int idMere)
        {
            var x = _rep.DonnerEnfantsSansPere(idMere);
            return x==null?null:x.Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfantsSurs(int id, bool pere)
        {
            var x = _rep.DonnerEnfantsSurs(id, pere);
            return x==null?null:x.Select(l => l.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<Descendant> DonnerLesEnfants(int id)
        {
            return _rep.DonnerLesEnfants(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }
    }
}
