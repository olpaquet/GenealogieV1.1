//using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Genealogie.ASP.Models;

namespace Genealogie.ASP.Services.API
{
    public class VMessageRecuServiceAPI : BaseServiceAPI /*,IVMessageRecuRepository<VMessageRecu>*/
    {
        public IEnumerable<VMessageRecu> Donner(int idConversation, int idDestinataire)
        {
            HttpResponseMessage reponse = _client.GetAsync($"VMessageRecu/Donner/{idConversation}/{idDestinataire}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<VMessageRecu>>().Result;
        }

        public IEnumerable<VMessageRecu> DonnerPoubellePourDestinataire(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"VMessageRecu/DonnerPoubellePourDestinataire/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<VMessageRecu>>().Result;
        }

        public IEnumerable<VMessageRecu> DonnerPourDestinataire(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"VMessageRecu/DonnerPourDestinataire/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<VMessageRecu>>().Result;
        }

        public IEnumerable<VMessageRecu> DonnerConversationComplete(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"VMessageRecu/DonnerConversationComplete/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<VMessageRecu>>().Result;
        }
    }
}