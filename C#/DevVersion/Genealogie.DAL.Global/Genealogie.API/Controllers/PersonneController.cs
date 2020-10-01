using Genealogie.API.Autentification;
using Genealogie.API.Conversion;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
using Genealogie.Modeles.API.ASP.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genealogie.API.Controllers
{
    [AutBase("-")]
    public class PersonneController : ApiController
    {
        [HttpGet]
        public Personne Donner(int id)
        {
            return new PersonneService().Donner(id).VersAPI();
        }
        [HttpGet]
        public IEnumerable<Personne> DonnerPourArbre(int id)
        {
            return new PersonneService().DonnerPourArbre(id).Select(j => j.VersAPI());
        }
        [HttpPut]
        public IEnumerable<Personne> Chercher(Recherche e)
        {
            return new PersonneService().Rechercher(e).Select(j => j.VersAPI());
        }
        [HttpGet]
        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            return new PersonneService().DonnerEnfants(id).Select(j => j.VersAPI());
        }
        [HttpGet]
        public Personne DonnerPere(int id)
        {
            return new PersonneService().DonnerPere(id).VersAPI();
        }
        [HttpGet]
        public Personne DonnerMere(int id)
        {
            return new PersonneService().DonnerMere(id).VersAPI();
        }

        [HttpGet]
        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(int id)
        {
            return new PersonneService().DonnerParenteesDirectesPossibles(id).Select(j => j.VersAPI());
        }


        [HttpPost]
        public int Creer(Personne e)
        {
            return new PersonneService().Creer(e.VersClient());
        }

        [HttpPut]
        public bool AjouterEnfant(ParentEnfant e)
        {
            return new PersonneService().AjouterEnfant(e.idParent, e.idEnfant);
        }

        [HttpPut]
        public bool SupprimerEnfant(ParentEnfant e)
        {
            return new PersonneService().SupprimerEnfant(e.idParent, e.idEnfant);
        }

        [HttpPut]
        public bool AjouterParent(ParentEnfant e)
        {
            return new PersonneService().AjouterParent(e.idEnfant, e.idParent);
        }

        [HttpPut]
        public bool SupprimerPere(int id)
        {
            return new PersonneService().SupprimerPere(id);
        }
        [HttpPut]
        public bool SupprimerMere(int id)
        {
            return new PersonneService().SupprimerMere(id);
        }

        [HttpPut]
        public bool Modifier(int id, Personne e)
        {
            PersonneService us = new PersonneService();
            return us.Modifier(id, e.VersClient());
        }

        [HttpPut]
        public IEnumerable<Personne> Rechercher(Recherche rec)
        {
            return new PersonneService().Rechercher(rec).Select(j=>j.VersAPI());
        }

        




    }
}
