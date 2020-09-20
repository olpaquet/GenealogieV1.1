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
    public class AbonnementController : ApiController /*, IAbonnementRepository<Abonnement>*/
    {
        [HttpGet]
        public IEnumerable<Abonnement> Donner()
        {
            AbonnementService us = new AbonnementService();

            return us.Donner().Select(j => j.VersAPI());
        }



        [HttpGet]
        public Abonnement Donner(int id)
        {
            AbonnementService us = new AbonnementService();
            return us.Donner(id).VersAPI();
        }

        [HttpPut]
        public int? DonnerParNom(ChercherPar cp)
        {
            AbonnementService rs = new AbonnementService();
            return rs.DonnerParNom(cp.chercheString);
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<Abonnement> Donner(ObjetDonnerListe odl)
        {
            AbonnementService rs = new AbonnementService();
            return rs.Donner(odl.ienum, odl.options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Activer(int id)
        {
            AbonnementService us = new AbonnementService();
            return us.Activer(id);

        }

        [HttpPut]
        public bool Desactiver(int id)
        {
            AbonnementService us = new AbonnementService();
            return us.Desactiver(id);
        }

        [HttpPut]
        public bool Modifier(int id, Abonnement e)
        {
            AbonnementService us = new AbonnementService();
            return us.Modifier(id, e.VersClient());
        }

        [HttpPost]
        public int Creer(Abonnement e)
        {
            AbonnementService us = new AbonnementService();
            return us.Creer(e.VersClient());
        }

        [HttpDelete]
        public bool Supprimer(int id)
        {
            AbonnementService rs = new AbonnementService();
            return rs.Supprimer(id);
        }

        [HttpGet]
        public bool EstUtilisee(int id)
        {
            AbonnementService rs = new AbonnementService();
            return rs.EstUtilisee(id, null);
        }



    }
}
