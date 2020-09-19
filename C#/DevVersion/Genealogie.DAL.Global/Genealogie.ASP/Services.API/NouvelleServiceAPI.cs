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
    public class NouvelleServiceAPI : BaseServiceAPI /*, INouvelleRepository<Nouvelle>*/
    {
        public bool Activer(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Nouvelle/Activer/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public int Creer(Nouvelle e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Nouvelle/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToInt32((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Nouvelle/Desactiver/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public IEnumerable<Nouvelle> Donner()
        {
            HttpResponseMessage reponse = _client.GetAsync($"Nouvelle/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Nouvelle>>().Result;
            throw new NotImplementedException();
        }

        public Nouvelle Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Nouvelle/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<Nouvelle>().Result;
            throw new NotImplementedException();
        }

        public IEnumerable<Nouvelle> Donner(ObjetDonnerListe e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Nouvelle/Donner/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Nouvelle>>().Result;
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Nouvelle e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Nouvelle/Modifier/{id}", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
            throw new NotImplementedException();
        }

        public bool Supprimer(int id)
        {
            HttpResponseMessage reponse = _client.DeleteAsync($"Nouvelle/Supprimer/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Nouvelle/EstUtilisee/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return bool.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }
    }
}