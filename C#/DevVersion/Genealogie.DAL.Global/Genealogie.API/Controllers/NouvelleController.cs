using Genealogie.API.Conversion;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genealogie.API.Controllers
{
    public class NouvelleController : ApiController /*, INouvelleRepository<Nouvelle>*/
    {
        [HttpGet]
        public IEnumerable<Nouvelle> Donner()
        {
            NouvelleService us = new NouvelleService();

            return us.Donner().Select(j => j.VersAPI());
        }



        [HttpGet]
        public Nouvelle Donner(int id)
        {
            NouvelleService us = new NouvelleService();
            return us.Donner(id).VersAPI();
        }

        [HttpPut]
        public IEnumerable<Nouvelle> Donner(ObjetDonnerListe odl)
        {
            NouvelleService rs = new NouvelleService();
            return rs.Donner(odl.ienum, odl.options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Activer(int id)
        {
            NouvelleService us = new NouvelleService();
            return us.Activer(id);

        }

        [HttpPut]
        public bool Desactiver(int id)
        {
            NouvelleService us = new NouvelleService();
            return us.Desactiver(id);
        }

        [HttpPut]
        public bool Modifier(int id, Nouvelle e)
        {
            NouvelleService us = new NouvelleService();
            return us.Modifier(id, e.VersClient());
        }

        [HttpPost]
        public int Creer(Nouvelle e)
        {
            NouvelleService us = new NouvelleService();
            return us.Creer(e.VersClient());
        }

        [HttpDelete]
        public bool Supprimer(int id)
        {
            NouvelleService rs = new NouvelleService();
            return rs.Supprimer(id);
        }

        [HttpGet]
        public bool EstUtilisee(int id)
        {
            NouvelleService rs = new NouvelleService();
            return rs.EstUtilisee(id, null);
        }
    }
}
