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
    public class PersonneController : ApiController
    {
        [HttpGet]
        public Personne Donner(int id)
        {
            return new PersonneService().Donner(id).VersAPI();
        }
        [HttpGet]
        public IEnumerable<Personne> DonnerParArbre(int id)
        {
            return new PersonneService().DonnerParArbre(id).Select(j => j.VersAPI());
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

        [HttpPut]
        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(ControleurPersonneRecherche e)
        {
            return new PersonneService().DonnerParenteesDirectesPossibles(e.idPersonne, e.idArbre).Select(j => j.VersAPI());
        }
    }
}
