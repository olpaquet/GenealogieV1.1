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
using Genealogie.API.Autentification;

namespace Genealogie.API.Controllers
{
    [AutBase("-")]
    public class VMessageRecuController : ApiController /*, IVMessageRecuRepository<VMessageRecu>*/
    {
        [HttpGet]
        public IEnumerable<VMessageRecu> DonnerConversationComplete(int id)
        {
            return new VMessageRecuService().DonnerConversationComplete(id).Select(j => j.VersAPI());
        }

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
