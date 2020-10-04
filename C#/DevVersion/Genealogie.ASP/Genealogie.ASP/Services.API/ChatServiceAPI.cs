using Genealogie.ASP.Models;
using Genealogie.Modeles.API.ASP.Modeles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Genealogie.ASP.Services.API
{
    public class ChatServiceAPI : BaseServiceAPI
    {

        public IEnumerable<Chat> Donner(int? idUtilisateur, DateTime? aPartirDe)
        {
            string contenuJson = JsonConvert.SerializeObject(new ChercherDansChat { idUtilisateur = idUtilisateur, aPartirDe=aPartirDe }, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.GetAsync($"Chat/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            IEnumerable<Chat> x = reponse.Content.ReadAsAsync<IEnumerable<Chat>>().Result;
            return x;
        }
  
        public Chat Donner(int id)
        {
            
            HttpResponseMessage reponse = _client.GetAsync($"Chat/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            Chat x = reponse.Content.ReadAsAsync<Chat>().Result;
            return x;
        }

    
        public int Creer(Chat e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Chat/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return int.Parse(x);
        }

        public bool Activer(int id)
        {

            HttpResponseMessage reponse = _client.PutAsync($"Chat/Activer/{id}",null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            string x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public bool Desactiver(int id)
        {

            HttpResponseMessage reponse = _client.PutAsync($"Chat/Desactiver/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            string x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

    }
}