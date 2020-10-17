using Genealogie.DAL.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Genealogie.API.Controllers
{
    public class CoupleController : ApiController
    {
        [HttpGet]
        public bool Creer(int id, int id2)
        {
            return new CoupleService().Creer(id,id2);
           
        }
        [HttpGet]
        public IEnumerable<int> Partenaires(int id)
        {
            return new CoupleService().Donner(id);
        }
        [HttpDelete]
        public bool Supprimer(int id, int id2)
        {
            return new CoupleService().Supprimer(id, id2);
        }

        [HttpGet]
        public bool EstEnCouple(int id, int id2)
        {
            return new CoupleService().EstEnCouple(id, id2);
        }
    }
}
