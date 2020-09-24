using Genealogie.API.Conversion;
using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Genealogie.API.Controllers
{
    public class ArbreController : ApiController /*, IArbreRepository<Arbre>*/
    {
        [HttpPost]
        public int Creer(Arbre e)
        {
            ArbreService us = new ArbreService();
            return us.Creer(e.VersClient());
        }

        [HttpGet]
        public IEnumerable<Arbre> Donner()
        {
            ArbreService us = new ArbreService();

            return us.Donner().Select(j => j.VersAPI());
        }
               
        [HttpGet]
        public Arbre Donner(int id)
        {
            ArbreService us = new ArbreService();
            return us.Donner(id).VersAPI();
        }

        [HttpPut]
        public IEnumerable<Arbre> Donner(ObjetDonnerListe odl)
        {
            ArbreService rs = new ArbreService();
            return rs.Donner(odl.ienum, odl.options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public int? DonnerParNom(ChercherPar cp)
        {
            ArbreService rs = new ArbreService();
            return rs.DonnerParNom(cp.chercheString, cp.chercheInt);
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<Arbre> DonnerParUtilisateur(int id)
        {
            ArbreService rs = new ArbreService();
            return rs.DonnerParUtilisateur(id).Select(l => l.VersAPI());
        }

        [HttpPut]
        public bool Activer(int id)
        {
            ArbreService us = new ArbreService();
            return us.Activer(id);

        }

        [HttpPut]
        public bool Desactiver(int id)
        {
            ArbreService us = new ArbreService();
            return us.Desactiver(id);
        }

        [HttpPut]
        public bool Modifier(int id, Arbre e)
        {
            ArbreService us = new ArbreService();
            return us.Modifier(id, e.VersClient());
        }

        

        [HttpDelete]
        public bool Supprimer(int id)
        {
            ArbreService rs = new ArbreService();
            return rs.Supprimer(id);
        }

        [HttpGet]
        public bool EstUtilisee(int id)
        {
            ArbreService rs = new ArbreService();
            return rs.EstUtilisee(id, null);
        }

        [HttpPut]
        public bool Bloquer(BlocageArbre e)
        {
            return new ArbreService().Bloquer(e);
        }

        [HttpPut]
        public bool Debloquer(int id)
        {
            return new ArbreService().Debloquer(id);
        }

        



    }
}
