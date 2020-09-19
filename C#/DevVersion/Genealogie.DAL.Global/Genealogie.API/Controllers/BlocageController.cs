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
    public class BlocageController : ApiController /*, IBlocageRepository<Blocage>*/
    {
        [HttpGet]
        public IEnumerable<Blocage> Donner()
        {
            BlocageService us = new BlocageService();

            return us.Donner().Select(j => j.VersAPI());
        }



        [HttpGet]
        public Blocage Donner(int id)
        {
            BlocageService us = new BlocageService();
            return us.Donner(id).VersAPI();
        }

        [HttpPut]
        public int? DonnerParNom(ChercherPar cp)
        {
            BlocageService rs = new BlocageService();
            return rs.DonnerParNom(cp.chercheString);
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<Blocage> Donner(ObjetDonnerListe odl)
        {
            BlocageService rs = new BlocageService();
            return rs.Donner(odl.ienum, odl.options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Activer(int id)
        {
            BlocageService us = new BlocageService();
            return us.Activer(id);

        }

        [HttpPut]
        public bool Desactiver(int id)
        {
            BlocageService us = new BlocageService();
            return us.Desactiver(id);
        }

        [HttpPut]
        public bool Modifier(int id, Blocage e)
        {
            BlocageService us = new BlocageService();
            return us.Modifier(id, e.VersClient());
        }

        [HttpPost]
        public int Creer(Blocage e)
        {
            BlocageService us = new BlocageService();
            return us.Creer(e.VersClient());
        }

        [HttpDelete]
        public bool Supprimer(int id)
        {
            BlocageService rs = new BlocageService();
            return rs.Supprimer(id);
        }

        [HttpGet]
        public bool EstUtilisee(int id)
        {
            BlocageService rs = new BlocageService();
            return rs.EstUtilisee(id, null);
        }

        

    }
}
