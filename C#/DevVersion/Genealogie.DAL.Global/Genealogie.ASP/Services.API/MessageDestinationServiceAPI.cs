using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
//using Genealogie.DAL.Global.Repository;
using Genealogie.ASP.Models;
using Newtonsoft.Json;

namespace Genealogie.ASP.Services.API
{
    public class MessageDestinationServiceAPI : BaseServiceAPI/*,IMessageDestinationRepository<MessageDestination>*/
    {
        /*
        string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
        StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
        HttpResponseMessage reponse = _client.PutAsync($"Arbre/Bloquer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
    }
    var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
    */
    public bool Creer(int id1, int id2, MessageDestination e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"MessageDestination/Creer/{id1}/{id2}", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
        
        public bool Detruire(int idConversation, int idDestinataire)
        {
            /*string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");*/
            HttpResponseMessage reponse = _client.PutAsync($"MessageDestination/Detruire/{idConversation}/{idDestinataire}",null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public IEnumerable<MessageDestination> Donner()
        {
            /*string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");*/
            HttpResponseMessage reponse = _client.GetAsync($"MessageDestination/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<MessageDestination>>().Result;
            return x;
        }

        public MessageDestination Donner(int id1, int id2)
        {
            /*string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");*/
            HttpResponseMessage reponse = _client.GetAsync($"MessageDestination/Donner/{id1}/{id2}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<MessageDestination>().Result;
            return x;
        }
        
        public bool Lire(int idConversation, int idDestinataire)
        {
            /*string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");*/
            HttpResponseMessage reponse = _client.GetAsync($"MessageDestination/Lire/{idConversation}/{idDestinataire}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public bool Modifier(int id1, int id2, MessageDestination e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"MessageDestination/Modifier/{id1}/{id2}", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public bool Supprimer(int id1, int id2)
        {
            /*string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");*/
            HttpResponseMessage reponse = _client.DeleteAsync($"MessageDestination/Supprimer/{id1}/{id2}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
    }
}