using Genealogie.ASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Genealogie.ASP.Services.API
{
    public class ConversationServiceAPI : BaseServiceAPI
    {
        
        public int Creer(Conversation e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Conversation/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return int.Parse(x);
        }

        
        public bool Detruire(int id)
        {
            
            HttpResponseMessage reponse = _client.PutAsync($"Conversation/Detruire/{id}",null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        
        public IEnumerable<Conversation> Donner()
        {
            HttpResponseMessage reponse = _client.GetAsync($"Conversation/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Conversation>>().Result;
            return x;
        }
        
        public Conversation Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Conversation/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<Conversation>().Result;
            return x;
        }
        
        public IEnumerable<Conversation> DonnerParEmetteur(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Conversation/DonnerParEmetteur/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Conversation>>().Result;
            return x;
        }

        public bool Modifier(int id, Conversation e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Conversation/Modifier/{id}",contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public bool Supprimer(int id)
        {
            HttpResponseMessage reponse = _client.DeleteAsync($"Conversation/Supprimer/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
    }
}