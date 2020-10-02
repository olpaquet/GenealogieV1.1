using Genealogie.API.Autentification;
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
    [AutBase("-")]
    public class ThemeController : ApiController /*, IThemeRepository<Theme>*/
    {
        [HttpGet]
        public IEnumerable<Theme> Donner()
        {
            ThemeService us = new ThemeService();

            return us.Donner().Select(j => j.VersAPI());
        }



        [HttpGet]
        public Theme Donner(int id)
        {
            ThemeService us = new ThemeService();
            return us.Donner(id).VersAPI();
        }

        [HttpPut]
        public int? DonnerParNom(ChercherPar cp)
        {
            ThemeService rs = new ThemeService();
            return rs.DonnerParNom(cp.chercheString);
            throw new NotImplementedException();
        }

        [HttpPut]
        public IEnumerable<Theme> Donner(ObjetDonnerListe odl)
        {
            ThemeService rs = new ThemeService();
            return rs.Donner(odl.ienum, odl.options).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool Activer(int id)
        {
            ThemeService us = new ThemeService();
            return us.Activer(id);

        }

        [HttpPut]
        public bool Desactiver(int id)
        {
            ThemeService us = new ThemeService();
            return us.Desactiver(id);
        }

        [HttpPut]
        public bool Modifier(int id, Theme e)
        {
            ThemeService us = new ThemeService();
            return us.Modifier(id, e.VersClient());
        }

        [HttpPost]
        public int Creer(Theme e)
        {
            ThemeService us = new ThemeService();
            return us.Creer(e.VersClient());
        }

        [HttpDelete]
        public bool Supprimer(int id)
        {
            ThemeService rs = new ThemeService();
            return rs.Supprimer(id);
        }

        [HttpGet]
        public bool EstUtilisee(int id)
        {
            ThemeService rs = new ThemeService();
            return rs.EstUtilisee(id, null);
        }
    }
}
