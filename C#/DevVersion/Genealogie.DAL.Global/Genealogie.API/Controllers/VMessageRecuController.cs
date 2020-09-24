using Genealogie.API.Models;
using Genealogie.DAL.Client.Services;
//using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Genealogie.API.Conversion;

namespace Genealogie.API.Controllers
{
    public class VMessageRecuController : ApiController /*, IVMessageRecuRepository<VMessageRecu>*/
    {
        [HttpGet]
        [Route("api/VMessageRecu/Donner/{id:int}/{id2:int}")]
        public IEnumerable<VMessageRecu> Donner(int idConvesation, int idDestinataire)
        {
            return new VMessageRecuService().Donner(idConvesation, idDestinataire).Select(j => j.VersAPI()); ;
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<VMessageRecu> DonnerPoubellePourDestinataire(int id)
        {
            return new VMessageRecuService().DonnerPoubellePourDestinataire(id).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<VMessageRecu> DonnerPourDestinataire(int id)
        {
            return new VMessageRecuService().DonnerPourDestinataire(id).Select(j => j.VersAPI());
            throw new NotImplementedException();
        }
    }
}
